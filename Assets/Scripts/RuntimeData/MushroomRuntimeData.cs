using UnityEngine;

public class MushroomRuntimeData : CharacterRuntimeData
{
    public MushroomRuntimeData(MushroomDefaultData data)
    {
        _character = data;
        _hp = data.HP;
        _power = data.Power;
        _defence = data.Defence;
        _speed = data.Speed;
    }
}
