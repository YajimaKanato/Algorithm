using UnityEngine;

public class WarriorInput : CharacterInput
{
    public override void MoveSetting()
    {
        _characterSystem.Move<WarriorRuntimeData>(_id, _characterView, transform.position, _target);
    }

    public override void TargetSetting()
    {
        _target = _targets[Random.Range(0, _targets.Length)].transform.position;
    }
}
