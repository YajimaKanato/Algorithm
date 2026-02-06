using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPool : MonoBehaviour
{
    [SerializeField] CharacterDefaultData _defaultData;
    [SerializeField] MoveCharacterInput _character;
    [SerializeField] Transform _transform;
    CharacterSystem _system;
    RuntimeDataRepository _repository;
    Queue<MoveCharacterInput> _queue;

    public static event Action SpawnAct;

    Vector3 _position;

    int _maxQueueCount = 10;
    int _nextID;
    bool _isInit;

    public void Init(CharacterSystem system, RuntimeDataRepository repository)
    {
        _system = system;
        _repository = repository;
        _queue = new();
        _position = _transform.position;
        _isInit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isInit) return;
    }

    public void Spawn()
    {
        MoveCharacterInput go;
        if (_queue.Count > 0)
        {
            go = _queue.Dequeue();
            go.gameObject.SetActive(true);
            go.transform.position = _position;
        }
        else
        {
            go = Instantiate(_character, _position, Quaternion.identity, transform);
            go.Init(_system);
            go.PoolSetting(this);
        }
        go?.StatusReset(_nextID, _defaultData.CreateRuntimeData(_repository, _nextID));
        _nextID++;
        SpawnAct?.Invoke();
    }

    public void ReleaseToPool(MoveCharacterInput character)
    {
        if (_queue.Count >= _maxQueueCount)
        {
            Destroy(character);
        }
        else
        {
            _queue.Enqueue(character);
            character.gameObject.SetActive(false);
        }
    }

    public void DummyFunc()
    {

    }

    private void OnDisable()
    {
        SpawnAct = null;
    }

    private void OnDestroy()
    {
        SpawnAct = null;
    }
}
