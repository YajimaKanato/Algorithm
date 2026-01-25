using UnityEngine;

public class WarriorRuntimeData : CharacterRuntimeData
{
    public WarriorRuntimeData(WarriorDefaultData data)
    {
        _character = data;
        _hp = data.HP;
        _power = data.Power;
        _defence = data.Defence;
        _speed = data.Speed;
    }
}
