using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPool : MonoBehaviour
{
    [SerializeField] int _maxSpawn = 10;
    [SerializeField] CharacterDefaultData _defaultData;
    [SerializeField] MoveCharacterInput _character;
    [SerializeField] Transform _transform;
    CharacterSystem _system;
    RuntimeDataRepository _repository;
    Queue<MoveCharacterInput> _queue;
    Node[] _nodes;

    Vector3 _position;

    int _spawnCount = 0;
    int _maxQueueCount = 10;
    int _nextID;

    public void Init(CharacterSystem system, RuntimeDataRepository repository, Node[] nodes)
    {
        _system = system;
        _repository = repository;
        _queue = new();
        _position = _transform.position;
        _nodes = nodes;
    }

    public void Spawn()
    {
        if (_spawnCount >= _maxSpawn) return;
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
            go.PoolSetting(this, _nodes);
        }
        go?.StatusReset(_nextID, _defaultData.CreateRuntimeData(_repository, _nextID));
        _nextID++;
        _spawnCount++;
    }

    public void ReleaseToPool(MoveCharacterInput character, int id)
    {
        if (_queue.Count >= _maxQueueCount)
        {
            Destroy(character);
            character = null;
        }
        else
        {
            _queue.Enqueue(character);
            character.gameObject.SetActive(false);
        }
        _defaultData.RemoveRuntimeData(_repository, id);
        _spawnCount--;
    }

    public void DummyFunc()
    {

    }

    private void OnDisable()
    {
        _queue = null;
        Debug.Log($"{name} : Remove");
    }

    private void OnDestroy()
    {
        _queue = null;
        Debug.Log($"{name} : Remove");
    }
}
