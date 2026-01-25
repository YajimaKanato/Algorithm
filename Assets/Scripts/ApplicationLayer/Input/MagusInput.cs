using UnityEngine;

public class MaguInput : CharacterInput
{
    public override void MoveSetting()
    {
        _characterSystem.Move<MagusRuntimeData>(_id, _characterView, transform.position, _target);
    }

    public override void TargetSetting()
    {
        _target = _targets[Random.Range(0, _targets.Length)].transform.position;
    }
}
