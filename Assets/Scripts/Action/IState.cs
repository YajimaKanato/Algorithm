using UnityEngine;

public interface IState
{
    public void Action(CharacterView view);
    public void ChangeState(CharacterView view);
}

public enum StateType
{
    Idle,
    Move,
    Chase,
    Attack,
    Die
}
