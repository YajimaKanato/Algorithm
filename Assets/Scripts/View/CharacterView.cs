using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(NavMeshAgent))]
public class CharacterView : MonoBehaviour
{
    [SerializeField] LineFlow _line;
    [SerializeField] float _stopDistance = 0.2f;
    Rigidbody _rb;
    Animator _animator;
    NavMeshAgent _agent;
    Vector3 _dir;
    float _speed;
    bool _isGoal;

    public bool IsGoal => _isGoal;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        tag = "Character";

        _agent.updatePosition = false;
        _agent.updateRotation = false;
        _agent.stoppingDistance = _stopDistance;

        _rb.isKinematic = false;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void OnEnable()
    {
        _isGoal = false;
    }

    private void FixedUpdate()
    {
        var desired = _agent.desiredVelocity;
        _dir = desired.normalized * _speed;
        _dir.y = _rb.linearVelocity.y;
        _rb.linearVelocity = _dir;
        _rb.AddForce(Vector3.down * 15, ForceMode.Force);
        _agent.nextPosition = _rb.position;
        if (_dir != Vector3.zero) transform.forward = _dir;
    }

    private void LateUpdate()
    {
        if (_animator) _animator.SetFloat("Speed", _speed);
    }

    public void Move(Node target, Node goal, float speed)
    {
        _agent.SetDestination(target.transform.position);
        _speed = speed;
        _isGoal = target == goal;
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
}
