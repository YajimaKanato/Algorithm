using UnityEngine;

public class CactusInput : CharacterInput
{
    public override void MoveSetting()
    {
        _characterSystem.Move<CactusRuntimeData>(_id, _characterView, gameObject, _target.gameObject);
    }

    public override GameObject TargetInfo()
    {
        var targets = GameObject.FindGameObjectsWithTag("Character");
        var target = targets.Length <= 0 ? null : targets[Random.Range(0, targets.Length)];
        return target;
    }
}
