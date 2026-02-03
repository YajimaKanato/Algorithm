using UnityEngine;
using System.Collections.Generic;

public abstract class PrioritySystem : ScriptableObject
{
    public abstract GameObject GetTarget(GameObject currentTarget, GameObject newTarget);
}
