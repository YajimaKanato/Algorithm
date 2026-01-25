using UnityEngine;

public class MimicRuntimeData : CharacterRuntimeData
{
    public MimicRuntimeData(MimicDefaultData data)
    {
        _character = data;
        _hp = data.HP;
        _power = data.Power;
        _defence = data.Defence;
        _speed = data.Speed;
    }
}
