using System;
using System.Collections.Generic;
using UnityEngine;

public class AStarAlgorithm
{
    Node[] _nodes;
    Dictionary<Node, AStarRecord> _record;

    public AStarAlgorithm(Node[] nodes)
    {
        _nodes = nodes;
    }

    /// <summary>
    /// 指定した座標に最も近いノードを返す関数
    /// </summary>
    /// <param name="pos">近いノードがどこかを調べる対象の座標</param>
    /// <returns>指定した座標に最も近いノード</returns>
    public Node NearestNode(GameObject pos)
    {
        Node result = null;
        float sqrtDistance = float.MaxValue;
        foreach (var node in _nodes)
        {
            var compareSqrtDistance = Vector3.SqrMagnitude(node.transform.position - pos.transform.position);
            if (sqrtDistance > compareSqrtDistance)
            {
                result = node;
                sqrtDistance = compareSqrtDistance;
            }
        }
        return result;
    }

    public List<Node> AStar(Node start, Node goal, Vector3 startPos, Vector3 goalPos)
    {
        //リスト作成
        var openList = new PriorityQueue<Node, float>();
        var closedList = new HashSet<Node>();
        _record = new Dictionary<Node, AStarRecord>();

        //スタート設定
        var newG = 0f;
        var newH = Heuristic(startPos, goalPos);
        var newF = newG + newH;
        _record[start] = new(newG, newH, newF, null);
        openList.Enqueue(start, newF);

        while (openList.Count > 0)
        {
            var currentNode = openList.Dequeue();
            if (currentNode.element == goal) return BuildPath(goal, goalPos);
            closedList.Add(currentNode.element);

            foreach (var adj in currentNode.element.Nodeds)
            {
                if (closedList.Contains(adj.Node)) continue;
                newG = _record[currentNode.element].G + adj.Cost;
                var isNew = !_record.ContainsKey(adj.Node);
                if (isNew || _record[adj.Node].G > newG)
                {
                    newH = Heuristic(adj.Node.transform.position, goalPos);
                    newF = newG + newH;
                    _record[adj.Node] = new(newG, newH, newF, currentNode.element);
                    if (isNew)
                    {
                        openList.Enqueue(adj.Node, newF);
                    }
                    else
                    {
                        openList.BuildHeap();
                    }
                }
            }
        }
        return null;
    }

    float Heuristic(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b);
    }

    List<Node> BuildPath(Node goal, Vector3 goalPos)
    {
        var path = new List<Node>() { goal };
        var currentNode = _record[goal].Parent;
        while (currentNode != null)
        {
            path.Add(currentNode);
            currentNode = _record[currentNode].Parent;
        }
        path.Reverse();
        return path;
    }
}

public class AStarRecord
{
    Node _parent;
    float _g;
    float _h;
    float _f = float.MaxValue;

    public Node Parent => _parent;
    public float G => _g;
    public float H => _h;
    public float F => _f;

    public AStarRecord(float g, float h, float f, Node parent)
    {
        _g = g;
        _h = h;
        _f = f;
        _parent = parent;
    }
}

public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
{
    List<(TElement element, TPriority priority)> _list = new();
    public int Count => _list.Count;

    public void Enqueue(TElement element, TPriority priority)
    {
        _list.Add((element, priority));
        EnqueueHeapify();
    }

    public (TElement element, TPriority priority) Dequeue()
    {
        if (_list.Count <= 0) throw new InvalidOperationException("PriorityQueue is empty");
        var index = _list.Count - 1;
        (_list[0], _list[index]) = (_list[index], _list[0]);
        var element = _list[index];
        _list.RemoveAt(index);
        Heapify(0);
        return element;
    }

    public (TElement element, TPriority priority) Peek()
    {
        if (_list.Count <= 0) throw new InvalidOperationException("PriorityQueue is empty");
        return _list[0];
    }

    public bool Contains(TElement element)
    {
        foreach (var item in _list)
        {
            if (item.Equals(element)) return true;
        }
        return false;
    }

    public void BuildHeap()
    {
        var n = _list.Count;
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(i);
        }
    }

    void EnqueueHeapify()
    {
        int child = _list.Count - 1;
        while (true)
        {
            if (child <= 0) break;
            int parent = (child - 1) / 2;
            if (_list[parent].priority.CompareTo(_list[child].priority) < 0) break;
            (_list[parent], _list[child]) = (_list[child], _list[parent]);
            child = parent;
        }
    }

    void Heapify(int parent)
    {
        int size = _list.Count;
        while (true)
        {
            int childLeft = 2 * parent + 1;
            int childRight = childLeft + 1;
            if (childLeft >= size) break;
            int smallerChild = childLeft;
            if (childRight < size && _list[childLeft].priority.CompareTo(_list[childRight].priority) > 0)
            {
                smallerChild = childRight;
            }

            if (_list[parent].priority.CompareTo(_list[smallerChild].priority) < 0) break;
            (_list[parent], _list[smallerChild]) = (_list[smallerChild], _list[parent]);
            parent = smallerChild;
        }
    }
}
