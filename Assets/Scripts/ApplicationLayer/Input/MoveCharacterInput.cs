using UnityEngine;

public abstract class MoveCharacterInput : CharacterInput
{
    [SerializeField] PriorityData _priority;
    [SerializeField] float _targetRange = 5f;
    [SerializeField] string _enemyTag;
    protected CharacterPool _pool;
    protected Node[] _nodes;
    protected CharacterInput _target;
    protected GameObject _targetGameObject;

    public PriorityData Priority => _priority;
    public float TargetRange => _targetRange;

    public void PoolSetting(CharacterPool pool)
    {
        _pool = pool;
        _nodes = FindObjectsByType<Node>(FindObjectsSortMode.None);
    }

    private void Update()
    {
        if (!_isInit) return;
        if (_characterView.IsGoalArrived)
        {
            Arrived();
        }
        else
        {
            if (_characterView.IsArrived())
            {
                if (_characterView.IsGoal)
                {
                    TargetSetting();
                }
                else
                {
                    MoveSetting();
                }
            }
        }
        if (_characterView.StateType == StateType.Die)
        {
            _characterSystem.Die(_characterView);
            ReleaseToPool();
        }
    }

    public override void StatusReset(int id)
    {
        base.StatusReset(id);
        MoveSetting();
        CharacterPool.SpawnAct += TargetSetting;
    }

    void TargetSetting()
    {
        _target = BlackBoard.GetTarget(this);
        _targetGameObject = _target ? _target.gameObject : GetRandomNode();
    }

    protected GameObject GetRandomNode()
    {
        return _nodes[Random.Range(0, _nodes.Length)].gameObject;
    }

    public abstract void MoveSetting();

    protected abstract void Arrived();

    void ReleaseToPool()
    {
        CharacterPool.SpawnAct -= TargetSetting;
        _pool.ReleaseToPool(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tag)) TargetSetting();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_enemyTag)) Debug.Log($"{name} : Damage");
    }
}
