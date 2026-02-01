using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PriorityData", menuName = "Priority/PriorityData")]
public class PriorityData : ScriptableObject
{
    [SerializeField] Priority[] _priorities;
    Dictionary<PriorityType, int> _priority;

    public int GetPriority(PriorityType priorityType)
    {
        if (_priority == null)
        {
            _priority = new Dictionary<PriorityType, int>();
            foreach (var keyValuePair in _priorities)
            {
                _priority[keyValuePair.PriorityType] = keyValuePair.PriorityValue;
            }
        }
        if (_priority.TryGetValue(priorityType, out int value)) return -1;
        return value;
    }
}

[System.Serializable]
public class Priority
{
    [SerializeField] PriorityType _priorityType;
    [SerializeField] int _priorityValue;

    public PriorityType PriorityType => _priorityType;
    public int PriorityValue => _priorityValue;
}

public enum PriorityType
{
    [InspectorName("味方")] Support,
    [InspectorName("敵")] Enemy,
    [InspectorName("木")] Tree,
    [InspectorName("岩")] Rock,
    [InspectorName("草")] Grass,
    [InspectorName("宝")] Treasure
}
