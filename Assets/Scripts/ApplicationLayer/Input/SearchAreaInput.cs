using UnityEngine;

public class SearchAreaInput : MonoBehaviour
{
    CharacterInput _input;

    public void Init(CharacterInput input)
    {
        _input = input;
    }

    private void OnTriggerEnter(Collider other)
    {
        var target = other.gameObject;
        _input.RegisterTarget(target);
    }

    private void OnTriggerExit(Collider other)
    {
        var target = other.gameObject;
        _input.RemoveTarget(target);
    }
}
