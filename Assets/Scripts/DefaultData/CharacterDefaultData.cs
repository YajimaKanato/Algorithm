using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDefaultData", menuName = "DefaultData/CharacterDefaultData")]
public class CharacterDefaultData : ScriptableObject
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _maxSpeed = 10f;

    public float Speed => _speed;
    public float MaxSpeed => _maxSpeed;
}
