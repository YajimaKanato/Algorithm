using UnityEngine;
using UnityEngine.AI;

public class Sample : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform _transform;

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_transform.position);
    }
}
