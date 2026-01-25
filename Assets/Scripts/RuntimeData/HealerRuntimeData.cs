using UnityEngine;

public class HealerRuntimeData : CharacterRuntimeData
{
    public HealerRuntimeData(HealerDefaultData data)
    {
        _character = data;
        _hp = data.HP;
        _power = data.Power;
        _defence = data.Defence;
        _speed = data.Speed;
    }
}
