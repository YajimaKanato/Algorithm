using UnityEngine;

public abstract class MoveCharacterInput : CharacterInput
{
    [SerializeField] PriorityData _priority;
    [SerializeField] float _targetRange = 5f;
    [SerializeField] protected string _enemyTag;
    [SerializeField] float _removeInterval = 1;
    protected CharacterPool _pool;
    protected Node[] _nodes;
    protected CharacterInput _target;
    protected GameObject _targetGameObject;

    float _delta = 0;

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

        if (_characterView.StateType == StateType.Die)
        {
            ReleaseToPool();
        }
        else
        {
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
                        _targetGameObject = null;
                    }
                    _delta = 0;
                    TargetSetting();
                    MoveSetting();
                }

                _delta += Time.deltaTime;
                if (_delta >= _removeInterval)
                {
                    _delta = 0;
                    TargetSetting();
                    MoveSetting();
                }
            }
        }
    }

    public override void StatusReset(int id, CharacterRuntimeData runtime)
    {
        base.StatusReset(id, runtime);
        MoveSetting();
        CharacterPool.SpawnAct += TargetSetting;
    }

    void TargetSetting()
    {
        var newTarget = BlackBoard.GetTarget(this);
        if (newTarget)
        {
            _target = newTarget;
            _targetGameObject = newTarget.gameObject;
        }
        else
        {
            _targetGameObject ??= GetRandomNode();
        }
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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(tag)) TargetSetting();
    }
}
