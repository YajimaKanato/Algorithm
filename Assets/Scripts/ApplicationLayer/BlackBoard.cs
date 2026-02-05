using UnityEngine;
using System.Collections.Generic;

public static class BlackBoard
{
    static List<CharacterInput> _sceneObjects = new();

    public static CharacterInput GetTarget(MoveCharacterInput input)
    {
        if (_sceneObjects.Count <= 0) return null;
        var targetList = new List<CharacterInput>();
        var range = input.TargetRange * input.TargetRange;
        foreach (var obj in _sceneObjects)
        {
            if (obj == input) continue;
            if (Vector3.SqrMagnitude(input.transform.position - obj.transform.position) < range)
            {
                targetList.Add(obj);
            }
        }
        if (targetList.Count <= 0) return null;

        var priorities = input.Priority;
        var currentPriority = -1f;
        CharacterInput target = null;
        foreach (var obj in targetList)
        {
            var priority = priorities.GetPriority(obj.PriorityType);
            if (priority == -1) continue;
            var newPriority = priority + range - Vector3.SqrMagnitude(input.transform.position - obj.transform.position);
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
