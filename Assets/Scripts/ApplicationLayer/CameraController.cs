using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] InputActionAsset _actionAsset;
    [SerializeField] GameObject[] _cinemaChines;
    [SerializeField] GameObject _followCamera;
    [SerializeField] int _index;

    RaycastHit _hit;

    private void Start()
    {
        for (int i = 0; i < _cinemaChines.Length; i++)
        {
            Debug.Log(_cinemaChines[i]);
            _cinemaChines[i].gameObject.SetActive(i == 0);
        }
        _followCamera.gameObject.SetActive(false);
        _actionAsset.FindAction("Click").started += Click;
    }

    void Click(InputAction.CallbackContext context)
    {
        var pointer = Pointer.current;
        if (pointer == null) return;
        var dir = Camera.main.ScreenPointToRay(pointer.position.ReadValue());
        if (Physics.Raycast(dir, out _hit))
        {
            if (_hit.collider.CompareTag("Character"))
            {
                CameraFollow();
                return;
            }
        }
        CancelFollow();
    }

    public void NextCamera()
    {
        _cinemaChines[_index].gameObject.SetActive(false);
        _index++;
        if (_index > _cinemaChines.Length - 1) _index = 0;
        _cinemaChines[_index].gameObject.SetActive(true);
    }

    public void BackCamera()
    {
        _cinemaChines[_index].gameObject.SetActive(false);
        _index--;
        if (_index < 0) _index = _cinemaChines.Length - 1;
        _cinemaChines[_index].gameObject.SetActive(true);
    }

    void CameraFollow()
    {
        _followCamera.gameObject.SetActive(true);
        _followCamera.GetComponent<CinemachineVirtualCameraBase>().Follow = _hit.collider.transform;
    }

    public void CancelFollow()
    {
        if (!_followCamera.activeSelf) return;
        _followCamera.GetComponent<CinemachineVirtualCameraBase>().Follow = null;
        _followCamera.gameObject.SetActive(false);
    }
}
