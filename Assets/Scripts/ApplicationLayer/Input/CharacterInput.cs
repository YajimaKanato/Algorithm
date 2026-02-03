using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterView))]
public class CharacterInput : MonoBehaviour
{
    [SerializeField] protected CharacterView _characterView;
    [SerializeField] protected PriorityType _priorityType;

    protected CharacterSystem _characterSystem;

    protected int _id;
    protected bool _isInit;

    public PriorityType PriorityType => _priorityType;

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

    public virtual void StatusReset(int id)
    {
        _id = id;
    }
}
