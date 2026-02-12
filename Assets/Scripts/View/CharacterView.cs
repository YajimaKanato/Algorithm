using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

//[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(NavMeshAgent))]
public class CharacterView : MonoBehaviour
{
    [SerializeField] GameObject _dieObject;
    [SerializeField] LineFlow _line;
    [SerializeField] float _stopDistance = 0.2f;
    [SerializeField] float _attackRange = 1f;
    Rigidbody _rb;
    Animator _animator;
    NavMeshAgent _agent;
    CharacterInput _target;
    GameObject _preTarget;
    StateType _stateType = StateType.Idle;
    Vector3 _dir;
    float _speed;
    bool _isGoal;
    bool _isArrived;

    public StateType StateType => _stateType;
    public bool IsGoal => _isGoal;
    public bool IsGoalArrived => _isArrived;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();

        //_agent.updatePosition = false;
        _agent.updatePosition = true;
        //_agent.updateRotation = false;
        _agent.updateRotation = true;
        _agent.stoppingDistance = _stopDistance;

        //_rb.isKinematic = false;
        //_rb.isKinematic = true;
        //_rb.constraints = RigidbodyConstraints.FreezeRotation;
        _agent.SetDestination(new Vector3(-26.49f, 51.1f, -21.78f));
    }

    private void OnEnable()
    {
        if (!_animator) _animator = GetComponent<Animator>();
        _isGoal = false;
        _isArrived = false;
    }

    private void OnDisable()
    {
        if (_animator) _animator = null;
    }

    private void Update()
    {
        if (_target)
        {
            _isArrived = _target && _target.gameObject.activeSelf && Vector3.Distance(transform.position, _target.transform.position) <= _attackRange;
        }
        else
        {
            _isArrived = false;
        }
    }

    private void FixedUpdate()
    {
        //if (_stateType == StateType.Move) Move();
    }

    private void LateUpdate()
    {
        if (_animator) _animator.SetFloat("Speed", _speed);
    }

    public void Move(Node next, Node goal, GameObject target, float speed)
    {
        if (_animator) _animator.SetBool("Attack", false);
        _isGoal = next == goal;
        _target = target.GetComponent<CharacterInput>();
        _speed = speed;
        if (_preTarget != next.gameObject)
        {
            if (_isGoal)
            {
                Debug.Log("");
                _preTarget = target.gameObject;
                _agent.SetDestination(target.transform.position);
            }
            else
            {
                Debug.Log("");
                _preTarget = next.gameObject;
                _agent.SetDestination(next.transform.position);
            }
        }
        _stateType = StateType.Move;
    }

    public void LineSetting(List<Vector3> nodes, GameObject target, float speed)
    {
        if (_line && _line.gameObject.activeSelf) _line.LineSetting(nodes, target, speed);
    }

    public bool IsArrived()
    {
        return !_agent.pathPending &&
               _agent.remainingDistance <= _agent.stoppingDistance;
    }

    public void Move()
    {
        //Debug.Log(_agent.destination);
        var desired = _agent.desiredVelocity;
        _dir = desired.normalized * _speed;
        _dir.y = _rb.linearVelocity.y;
        _rb.linearVelocity = _dir;
        _rb.AddForce(Vector3.down * 15, ForceMode.Force);
        _agent.nextPosition = _rb.position;
        if (_dir != Vector3.zero) transform.forward = _dir;
    }

    public void Attack()
    {
        Debug.Log("Attack");
        _speed = 0;
        _rb.linearVelocity = Vector3.zero;
        _agent.nextPosition = _rb.position;
        transform.forward = _target.transform.position - transform.position;
        if (_animator) _animator.SetBool("Attack", true);
        _stateType = StateType.Attack;
    }

    public void Idle()
    {
        _stateType = StateType.Idle;
    }

    public void Die()
    {
        if (_dieObject) Instantiate(_dieObject, transform.position, transform.rotation);
        _stateType = StateType.Die;
    }
}
