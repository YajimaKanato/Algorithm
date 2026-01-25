using UnityEngine;

public abstract class CharacterDefaultData : ScriptableObject, IDefault
{
    [SerializeField] int _cost;
    [SerializeField] int _hp;
    [SerializeField] int _power;
    [SerializeField] int _defence;
    [SerializeField] float _speed = 5f;

    public int Cost => _cost;
    public int HP => _hp;
    public int Power => _power;
    public int Defence => _defence;
    public float Speed => _speed;

    public abstract void CreateRuntimeData(RuntimeDataRepository repository, int id);
}
