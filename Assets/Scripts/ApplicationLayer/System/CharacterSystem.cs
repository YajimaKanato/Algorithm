using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSystem
{
    RuntimeDataRepository _repository;
    Node[] _nodes;

    public CharacterSystem(RuntimeDataRepository repository, Node[] nodes)
    {
        _repository = repository;
        _nodes = nodes;
    }

    public void Move<T>(int id, CharacterView view, GameObject start, GameObject goal) where T : CharacterRuntimeData
    {
        if (!_repository.TryGetData<T>(id, out var data)) return;
        var astar = new AStarAlgorithm(_nodes);
        //最も近いノードを取得
        var startNode = astar.NearestNode(start);
        var goalNode = astar.NearestNode(goal);
        //AStar実行
        var nodes = astar.AStar(startNode, goalNode, start.transform.position, goal.transform.position);
        if (nodes != null) Debug.Log(string.Join("->", nodes));
        //Viewに情報を送る
        view.LineSetting(nodes.Select(n => n.transform.position).ToList(), goal, data.Speed);
        var node = nodes.Count > 1 ? nodes[1] : nodes[0];
        view.Move(node, goalNode, goal, data.Speed);
    }

    public void Damage<T>(int id, CharacterRuntimeData runtime, CharacterView view) where T : CharacterRuntimeData
    {
        if (!_repository.TryGetData<T>(id, out var data)) return;
        if(runtime == null) return;
        data.TakeDamage(runtime.Power);
        if (data.HP <= 0) view.Die();
    }

    public void Attack(CharacterView view)
    {
        view.Attack();
    }
}
