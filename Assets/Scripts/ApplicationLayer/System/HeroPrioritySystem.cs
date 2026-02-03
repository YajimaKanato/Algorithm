using UnityEngine;

public class HeroPrioritySystem : PrioritySystem
{
    public override GameObject GetTarget(GameObject currentTarget, GameObject newTarget)
    {
        if (!currentTarget) return newTarget;
        return null;
    }
}
