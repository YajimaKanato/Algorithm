using System.Collections.Generic;
using UnityEngine;

public class CharacterPool : MonoBehaviour
{
    [SerializeField] CharacterDefaultData _defaultData;
    [SerializeField] CharacterInput _character;
    CharacterSystem _system;
    RuntimeDataRepository _repository;
    Queue<CharacterInput> _queue;

    int _maxQueueCount = 10;
    int _nextID;
    bool _isInit;

    public void Init(CharacterSystem system, RuntimeDataRepository repository)
    {
        _system = system;
        _repository = repository;
        _queue = new Queue<CharacterInput>();
        _isInit = true;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isInit) return;
    }

    public void Spawn()
    {
        CharacterInput go;
        if (_queue.Count > 0)
        {
            go = _queue.Dequeue();
            go.gameObject.SetActive(true);
            go.transform.position = Vector3.zero;
        }
        else
        {
            go = Instantiate(_character, new Vector3(0, 1, 0), Quaternion.identity);
            go.Init(_system, this);
        }
        _defaultData.CreateRuntimeData(_repository, _nextID);
        go?.StatusReset(_nextID);
        _nextID++;
    }

    public void ReleaseToPool(CharacterInput character)
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
}
