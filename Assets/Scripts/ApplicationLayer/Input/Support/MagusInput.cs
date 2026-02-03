using UnityEngine;

public class MaguInput : MoveCharacterInput
{
    public override void MoveSetting()
    {
        _characterSystem.Move<MagusRuntimeData>(_id, _characterView, gameObject, _target ? _target.gameObject : GetRandomNode());
    }

    protected override void Arrived()
    {
        switch (_target.PriorityType)
        {
            case PriorityType.Support:
                break;
            case PriorityType.Enemy:
                _characterSystem.Attack(_characterView);
                break;
            case PriorityType.Tree:
                break;
            case PriorityType.Rock:
                break;
            case PriorityType.Grass:
                break;
        }
    }
}
