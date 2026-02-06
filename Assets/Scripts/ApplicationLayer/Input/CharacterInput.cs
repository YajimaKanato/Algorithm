using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterView))]
public class CharacterInput : MonoBehaviour
{
    [SerializeField] AttackField _attackField;
    [SerializeField] protected CharacterView _characterView;
    [SerializeField] protected PriorityType _priorityType;

    protected CharacterSystem _characterSystem;
    CharacterRuntimeData _runtime;

    protected int _id;
    protected bool _isInit;

    public AttackField AttackField => _attackField;
    public StateType StateType => _characterView.StateType;
    public PriorityType PriorityType => _priorityType;
    public CharacterRuntimeData Runtime => _runtime;

    public void Init(CharacterSystem characterSystem)
    {
        _characterSystem = characterSystem;
        _isInit = true;
    }

    private void OnEnable()
    {
        OnActivate();
    }

    private void OnDisable()
    {
        OnDeactivate();
    }

    protected virtual void OnActivate()
    {
        BlackBoard.ObjectRegister(this);
    }

    protected virtual void OnDeactivate()
    {
        BlackBoard.ObjectRemove(this);
    }

    public virtual void StatusReset(int id, CharacterRuntimeData runtime)
    {
        _id = id;
        _runtime = runtime;
        _attackField.Init(runtime);
    }
}
