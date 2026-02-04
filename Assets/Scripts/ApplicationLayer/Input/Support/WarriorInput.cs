using UnityEngine;

public class WarriorInput : MoveCharacterInput
{
    public override void MoveSetting()
    {
        if (!_targetGameObject) return;
        _characterSystem.Move<WarriorRuntimeData>(_id, _characterView, gameObject, _targetGameObject);
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
