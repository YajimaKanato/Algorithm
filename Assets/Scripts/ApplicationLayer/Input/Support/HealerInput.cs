using UnityEngine;

public class HealerInput : CharacterInput
{
    public override void MoveSetting()
    {
        if (!_target) return;
        _characterSystem.Move<HealerRuntimeData>(_id, _characterView, gameObject, _target.gameObject);
    }

    public override GameObject TargetInfo()
    {
        var targets = GameObject.FindGameObjectsWithTag("Enemy");
        var target = targets.Length <= 0 ? null : targets[Random.Range(0, targets.Length)];
        return target;
    }
}
