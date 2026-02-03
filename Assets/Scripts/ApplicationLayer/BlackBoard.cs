using UnityEngine;
using System.Collections.Generic;

public static class BlackBoard
{
    static List<CharacterInput> _sceneObjects = new();

    public static CharacterInput GetTarget(MoveCharacterInput input)
    {
        if (_sceneObjects.Count <= 0) return null;
        var targetList = new List<CharacterInput>();
        foreach (var obj in _sceneObjects)
        {
            if (obj == input) continue;
            if (Vector3.SqrMagnitude(input.transform.position - obj.transform.position) < input.TargetRange * input.TargetRange)
            {
                targetList.Add(obj);
            }
        }
        if (targetList.Count <= 0) return null;

        var priority = input.Priority;
        var currentPriority = -1;
        CharacterInput target = null;
        foreach (var obj in targetList)
        {
            var newPriority = priority.GetPriority(obj.PriorityType);
            if (currentPriority < newPriority)
            {
                target = obj;
                currentPriority = newPriority;
            }
        }
        return target;
    }

    public static void ObjectRegister(CharacterInput input)
    {
        if (!_sceneObjects.Contains(input)) _sceneObjects.Add(input);
    }

    public static void ObjectRemove(CharacterInput input)
    {
        if (_sceneObjects.Contains(input)) _sceneObjects.Remove(input);
    }
}
