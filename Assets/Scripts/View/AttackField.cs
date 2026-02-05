using UnityEngine;

public class AttackField : MonoBehaviour
{
    CharacterRuntimeData _runtime;
    public CharacterRuntimeData Runtime => _runtime;

    public void Init(CharacterRuntimeData runtime)
    {
        _runtime = runtime;
    }
}
