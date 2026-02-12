using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    RuntimeDataRepository _repository;
    CharacterSystem _characterSystem;
    CharacterPool[] _characterPools;
    Node[] _nodes;
    static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Init()
    {
        _repository = new RuntimeDataRepository();
        _characterSystem = new CharacterSystem(_repository);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BlackBoard.Clear();
        _nodes = FindObjectsByType<Node>(FindObjectsSortMode.None);
        _characterPools = FindObjectsByType<CharacterPool>(FindObjectsSortMode.None);
        foreach (var pool in _characterPools)
        {
            pool.Init(_characterSystem, _repository, _nodes);
        }
    }
}
