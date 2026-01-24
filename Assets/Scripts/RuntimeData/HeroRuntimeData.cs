using UnityEngine;

public class HeroRuntimeData : CharacterRuntimeData
{
    public HeroRuntimeData(HeroDefaultData data)
    {
        _character = data;
        _hp = data.HP;
        _power = data.Power;
        _defence = data.Defence;
        _speed = data.Speed;
    }
}
