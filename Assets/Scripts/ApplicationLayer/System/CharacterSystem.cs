using System.Collections.Generic;
using System.Linq;
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
        //最も近いノードを取得
        var startNode = AStarAlgorithm.Instance.NearestNode(start);
        var goalNode = AStarAlgorithm.Instance.NearestNode(goal);
        //AStar実行
        var nodes = AStarAlgorithm.Instance.AStar(startNode, goalNode, start.transform.position, goal.transform.position);
        if (nodes != null) Debug.Log(string.Join("->", nodes));
        //Viewに情報を送る
        view.LineSetting(nodes.Select(n => n.transform.position).ToList(), goal, data.Speed);
        var node = nodes.Count > 1 ? nodes[1] : nodes[0];
        view.Move(node, goalNode, data.Speed);
    }
}
