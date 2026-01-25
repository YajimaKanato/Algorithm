using UnityEngine;

public class MagusRuntimeData : CharacterRuntimeData
{
    public MagusRuntimeData(MagusDefaultData data)
    {
        _character = data;
        _hp = data.HP;
        _power = data.Power;
        _defence = data.Defence;
        _speed = data.Speed;
    }
}
