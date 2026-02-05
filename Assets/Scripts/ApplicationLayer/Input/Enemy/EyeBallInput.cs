using UnityEngine;

public class EyeBallInput : MoveCharacterInput
{
    public override void MoveSetting()
    {
        if (!_targetGameObject) return;
        _characterSystem.Move<EyeBallRuntimeData>(_id, _characterView, gameObject, _targetGameObject);
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
            _characterSystem.Damage<EyeBallRuntimeData>(_id, other.GetComponent<AttackField>().Runtime, _characterView);
        }
    }
}