using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(NavMeshAgent))]
public class CharacterView : MonoBehaviour
{
    [SerializeField] GameObject _dieObject;
    [SerializeField] LineFlow _line;
    [SerializeField] float _stopDistance = 0.2f;
    [SerializeField] float _attackRange = 1f;
    Rigidbody _rb;
    Animator _animator;
    NavMeshAgent _agent;
    GameObject _target;
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
        _animator = GetComponent<Animator>();

        _agent.updatePosition = false;
        _agent.updateRotation = false;
        _agent.stoppingDistance = _stopDistance;

        _rb.isKinematic = false;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void OnEnable()
    {
        _isGoal = false;
        _isArrived = false;
    }

    private void Update()
    {
        if (_target)
        {
            if (_target.TryGetComponent<CharacterInput>(out var character))
            {
                _isArrived = _target && _target.activeSelf && Vector3.Distance(transform.position, _target.transform.position) <= _attackRange;
            }
            else
            {
                _isArrived = false;
            }
        }
        else
        {
            _isArrived = false;
        }
    }

    private void FixedUpdate()
    {
        if (_stateType == StateType.Move) Move();
    }

    private void LateUpdate()
    {
        if (_animator) _animator.SetFloat("Speed", _speed);
    }

    public void Move(Node next, Node goal, GameObject target, float speed)
    {
        if (_animator) _animator.SetBool("Attack", false);
        _isGoal = next == goal;
        _target = target;
        _speed = speed;
        if (_isGoal)
        {
            _agent.SetDestination(target.transform.position);
        }
        else
        {
            _agent.SetDestination(next.transform.position);
        }
        _stateType = StateType.Move;
    }

    public void LineSetting(List<Vector3> nodes, GameObject target, float speed)
    {
        _line.LineSetting(nodes, target, speed);
    }

    public bool IsArrived()
    {
        return !_agent.pathPending &&
               _agent.remainingDistance <= _agent.stoppingDistance;
    }

    public void Move()
    {
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
        _speed = 0;
        _rb.linearVelocity = Vector3.zero;
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
