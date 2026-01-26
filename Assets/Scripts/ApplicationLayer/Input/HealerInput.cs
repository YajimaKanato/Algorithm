using UnityEngine;

public class HealerInput : CharacterInput
{
    public override void MoveSetting()
    {
        if (!_target) return;
        _characterSystem.Move<HealerRuntimeData>(_id, _characterView, gameObject, _target.gameObject);
    }

    public override void TargetSetting()
    {
        _target = _targets[Random.Range(0, _targets.Length)];
    }
}
