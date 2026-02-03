using UnityEngine;

public class CactusInput : MoveCharacterInput
{
    public override void MoveSetting()
    {
        _characterSystem.Move<CactusRuntimeData>(_id, _characterView, gameObject, _target ? _target.gameObject : GetRandomNode());
    }

    protected override void Arrived()
    {
        if (!_target) return;
        switch (_target.PriorityType)
        {
            case PriorityType.Support:
                _characterSystem.Attack(_characterView);
                break;
            case PriorityType.Treasure:
                break;
        }
    }
}
