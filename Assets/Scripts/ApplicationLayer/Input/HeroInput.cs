using UnityEngine;

public class HeroInput : CharacterInput
{
    public override void MoveSetting()
    {
        _characterSystem.Move<HeroRuntimeData>(_id, _characterView, gameObject, _target.gameObject);
    }

    public override void TargetSetting()
    {
        _target = _targets[Random.Range(0, _targets.Length)];
    }
}
