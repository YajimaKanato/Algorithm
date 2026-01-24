using UnityEngine;

public class CharacterRuntimeData : IRuntime
{
    protected CharacterDefaultData _character;

    protected int _hp;
    protected int _power;
    protected int _defence;
    protected float _speed = 5f;

    public int HP => _hp;
    public int Power => _power;
    public int Defence => _defence;
    public float Speed => _speed;

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp < 0) _hp = 0;
    }
}
