using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class CharacterView : MonoBehaviour
{
    NavMeshAgent _agent;
    Rigidbody _rb;
    Vector3 _start;
    Vector3 _dir;
    float _speed;
    bool _isGoal;

    public bool IsGoal => _isGoal;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _isGoal = false;
    }

    private void Update()
    {
        //_rb.linearVelocity = Vector3.MoveTowards(_start, _dir, _speed).normalized;
        _isGoal = !_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance;
    }

    public void Move(Vector3 start, Vector3 dir, float speed)
    {
        _start = start;
        _dir = dir;
        _speed = speed;
        Debug.Log(Vector3.MoveTowards(_start, _dir, _speed).normalized);
        _agent.SetDestination(start);
    }
}
