using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterView))]
public abstract class CharacterInput : MonoBehaviour
{
    [SerializeField] PriorityData _priority;
    [SerializeField] SearchAreaInput _searchArea;
    [SerializeField] protected CharacterView _characterView;
    protected CharacterSystem _characterSystem;
    protected CharacterPool _pool;
    protected Node[] _nodes;
    protected GameObject _target;
    List<GameObject> _targets;

    protected int _id;
    bool _isInit;

    public void Init(CharacterSystem characterSystem, CharacterPool pool)
    {
        _characterSystem = characterSystem;
        _pool = pool;
        _nodes = FindObjectsByType<Node>(FindObjectsSortMode.None);
        _targets = new List<GameObject>();
        _searchArea.Init(this);
        CharacterPool.SpawnAct += TargetSetting;
        _isInit = true;
    }

    public void StatusReset(int id)
    {
        _id = id;
        TargetSetting();
        MoveSetting();
    }

    private void Update()
    {
        if (!_isInit) return;
        if (_characterView.IsArrived())
        {
            if (_characterView.IsGoal) TargetSetting();
            MoveSetting();
        }
    }

    void TargetSetting()
    {
        _target = TargetInfo();
        if (!_target) _target = _nodes[Random.Range(0, _nodes.Length)].gameObject;
    }

    public abstract GameObject TargetInfo();

    public abstract void MoveSetting();

    public void RegisterTarget(GameObject target)
    {
        _targets.Add(target);
        TargetSetting();
    }

    public void RemoveTarget(GameObject target)
    {
        _targets.Remove(target);
        TargetSetting();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Character")) ReleaseToPool();
    }

    void ReleaseToPool()
    {
        CharacterPool.SpawnAct -= TargetSetting;
        _pool.ReleaseToPool(this);
    }
}
