using UnityEngine;

public class CactusRuntimeData : CharacterRuntimeData
{
    public CactusRuntimeData(CactusDefaultData data)
    {
        _character = data;
        _hp = data.HP;
        _power = data.Power;
        _defence = data.Defence;
        _speed = data.Speed;
    }
}
