using UnityEngine;

public class CharacterRuntimeData : IRuntime
{
    float _speed = 5f;
    float _maxSpeed = 10f;

    public float Speed => _speed;
    public float MaxSpeed => _maxSpeed;

    public CharacterRuntimeData(CharacterDefaultData character)
    {
        _speed = character.Speed;
        _maxSpeed = character.MaxSpeed;
    }
}
