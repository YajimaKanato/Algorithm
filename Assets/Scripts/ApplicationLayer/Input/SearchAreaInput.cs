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
        if (target.CompareTag(_tagName)) _input.RegisterTarget(target);
    }

    private void OnTriggerExit(Collider other)
    {
        var target = other.gameObject;
        if (target.CompareTag(_tagName)) _input.RemoveTarget(target);
    }
}
