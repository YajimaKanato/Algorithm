using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem
{
    RuntimeDataRepository _repository;

    public CharacterSystem(RuntimeDataRepository repository)
    {
        _repository = repository;
    }

    public void Move<T>(int id, CharacterView view, Vector3 start, Vector3 goal) where T : CharacterRuntimeData
    {
        if (!_repository.TryGetData<T>(id, out var data)) return;
        var startNode = AstarAlgorithm.Instance.NearestNode(start);
        var goalNode = AstarAlgorithm.Instance.NearestNode(goal);
        var node = AstarAlgorithm.Instance.PartlyAstar(startNode, goalNode);
        view.Move(node, goalNode, data.Speed);
        Debug.Log($"target => {node.name}\ngoal => {goalNode.name}");
    }
}
