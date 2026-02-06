using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform _pos;
    [SerializeField] string _targetTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterInput>() && other.CompareTag(_targetTag)) other.transform.position = _pos.position;
    }
}
