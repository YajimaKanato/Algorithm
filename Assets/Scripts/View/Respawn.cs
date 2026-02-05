using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform _pos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterInput>()) other.transform.position = _pos.position;
    }
}
