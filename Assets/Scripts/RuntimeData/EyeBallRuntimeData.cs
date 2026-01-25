using UnityEngine;

public class EyeBallRuntimeData : CharacterRuntimeData
{
    public EyeBallRuntimeData(EyeBallDefaultData data)
    {
        _character = data;
        _hp = data.HP;
        _power = data.Power;
        _defence = data.Defence;
        _speed = data.Speed;
    }
}
