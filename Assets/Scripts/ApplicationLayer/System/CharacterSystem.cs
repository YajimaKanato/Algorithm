using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem
{
    RuntimeDataRepository _repository;

    public CharacterSystem(RuntimeDataRepository repository)
    {
        _repository = repository;
    }

    public void Move<T>(int id, CharacterView view, GameObject start, GameObject goal) where T : CharacterRuntimeData
    {
        if (!_repository.TryGetData<T>(id, out var data)) return;
        var startNode = AstarAlgorithm.Instance.NearestNode(start);
        var goalNode = AstarAlgorithm.Instance.NearestNode(goal);
        var node = AstarAlgorithm.Instance.PartlyAstar(startNode, goalNode);
        Debug.Log($"target => {node.name}\ngoal => {goalNode.name}");
        var nodes = AstarAlgorithm.Instance.Astar(startNode, goalNode, start.transform.position, goal.transform.position);
        if (nodes != null) Debug.Log(string.Join("->", nodes));
        view.LineSetting(nodes, goal);
        view.Move(node, goalNode, data.Speed);
    }
}
