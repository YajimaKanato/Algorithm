using UnityEngine;

public class MushInput : MoveCharacterInput
{
    public override void MoveSetting()
    {
        if (!_targetGameObject) return;
        _characterSystem.Move<MushroomRuntimeData>(_id, _characterView, gameObject, _targetGameObject);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_enemyTag))
        {
            _characterSystem.Damage<MushroomRuntimeData>(_id, other.GetComponent<AttackField>().Runtime, _characterView);
        }
    }
}