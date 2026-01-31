using UnityEngine;

public class MimicInput : CharacterInput
{
    public override void MoveSetting()
    {
        _characterSystem.Move<MimicRuntimeData>(_id, _characterView, gameObject, _target.gameObject);
    }

    public override GameObject TargetInfo()
    {
        var targets = GameObject.FindGameObjectsWithTag("Character");
        var target = targets.Length <= 0 ? null : targets[Random.Range(0, targets.Length)];
        return target;
    }
}