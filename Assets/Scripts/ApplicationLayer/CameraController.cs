using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject[] _cinemaChines;
    [SerializeField] int _index;

    private void Start()
    {
        for(int i = 0; i < _cinemaChines.Length; i++)
        {
            _cinemaChines[i].SetActive(i == 0);
        }
    }

    public void NextCamera()
    {
        _cinemaChines[_index].SetActive(false);
        _index++;
        if (_index > _cinemaChines.Length - 1) _index = 0;
        _cinemaChines[_index].SetActive(true);
    }

    public void BackCamera()
    {
        _cinemaChines[_index].SetActive(false);
        _index--;
        if (_index < 0) _index = _cinemaChines.Length - 1;
        _cinemaChines[_index].SetActive(true);
    }
}
