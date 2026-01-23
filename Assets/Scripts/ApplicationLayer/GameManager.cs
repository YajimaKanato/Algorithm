using DataDriven;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    RuntimeDataRepository _repository;
    CharacterSystem _characterSystem;
    CharacterPool _characterPool;
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
        _characterPool = FindFirstObjectByType<CharacterPool>();
        _characterPool.Init(_characterSystem, _repository);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
