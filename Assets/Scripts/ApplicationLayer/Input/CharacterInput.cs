using UnityEngine;

[RequireComponent(typeof(CharacterView))]
public class CharacterInput : MonoBehaviour
{
    CharacterSystem _characterSystem;
    CharacterView _characterView;
    CharacterPool _pool;
    Node[] _targets;
    Node _target;

    Vector3 _targetPos;

    int _id;
    int _currentVec = 0;
    int _targetNodeSize = 100;
    float _destroyTime = 2f;
    float _delta;

    bool _isInit;
    bool _isMove;

    public void Init(CharacterSystem characterSystem, CharacterPool pool)
    {
        _characterSystem = characterSystem;
        _pool = pool;
        _characterView = GetComponent<CharacterView>();
        _isInit = true;
        _isMove = false;
    }

    public void StatusReset(int id)
    {
        _id = id;
        _delta = 0;
        Move();
        TargetSetting();
    }

    private void Update()
    {
        if (!_isInit) return;
        //if (_currentVec > _targetNodeSize)
        //{
        //    ReleaseToPool();
        //}
        //else
        //{
        //    if (_isMove && Vector3.Distance(_targetPos, transform.position) <= 1f)
        //    {
        //        TargetSetting();
        //    }
        //}
        if (_characterView.IsGoal) TargetSetting();
    }

    void Move()
    {
        _targets = FindObjectsByType<Node>(FindObjectsSortMode.None);
        //_characterSystem.Move(_id, this, _characterView, _target);
        _isMove = true;
    }

    public void NodeSizeSetting(int index)
    {
        _targetNodeSize = index;
        _currentVec = 0;
    }

    public void TargetSetting()
    {
        //_targetPos = _characterSystem.MoveSetting(_id, _characterView, _currentVec);
        //Debug.Log($"{_currentVec} : {_targetPos}");
        //_currentVec++;
        _target = _targets[Random.Range(0, _targets.Length)];
        _characterSystem.Move(_characterView, _target.transform.position);
    }

    void ReleaseToPool()
    {
        _pool.ReleaseToPool(this);
    }
}
