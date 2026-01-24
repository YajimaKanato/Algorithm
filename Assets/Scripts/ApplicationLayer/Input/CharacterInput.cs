using UnityEngine;

[RequireComponent(typeof(CharacterView))]
public abstract class CharacterInput : MonoBehaviour
{
    CharacterSystem _characterSystem;
    CharacterView _characterView;
    CharacterPool _pool;
    protected Node[] _targets;
    protected Vector3 _target;

    int _id;
    bool _isInit;

    public void Init(CharacterSystem characterSystem, CharacterPool pool)
    {
        _characterSystem = characterSystem;
        _pool = pool;
        _characterView = GetComponent<CharacterView>();
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

    public abstract void TargetSetting();

    public void MoveSetting()
    {
        _characterSystem.Move(_id, _characterView, transform.position, _target);
    }

    void ReleaseToPool()
    {
        _pool.ReleaseToPool(this);
    }
}
