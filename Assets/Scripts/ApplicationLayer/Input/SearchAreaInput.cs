using UnityEngine;

public class SearchAreaInput : MonoBehaviour
{
    [SerializeField] string _tagName;
    CharacterInput _input;

    public void Init(CharacterInput input)
    {
        _input = input;
    }

    private void OnTriggerEnter(Collider other)
    {
        var target = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        var target = other.gameObject;
    }
}
