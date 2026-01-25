using UnityEngine;

[RequireComponent(typeof(CharacterView))]
public abstract class CharacterInput : MonoBehaviour
{
    protected CharacterSystem _characterSystem;
    protected CharacterView _characterView;
    protected CharacterPool _pool;
    protected Node[] _targets;
    protected Vector3 _target;

    protected int _id;
    bool _isInit;

    public void Init(CharacterSystem characterSystem, CharacterPool pool)
    {
        _characterSystem = characterSystem;
        _pool = pool;
        _characterView = GetComponent<CharacterView>();
        _targets = FindObjectsByType<Node>(FindObjectsSortMode.None);
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

    public abstract void MoveSetting();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            ReleaseToPool();
        }
    }

    void ReleaseToPool()
    {
        _pool.ReleaseToPool(this);
    }
}
