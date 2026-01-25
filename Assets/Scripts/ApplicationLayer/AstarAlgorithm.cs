using System;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class AstarAlgorithm : MonoBehaviour
{
    Node[] _nodes;

    static AstarAlgorithm _instance;
    public static AstarAlgorithm Instance => _instance;
    public void Init()
    {
        if (_instance == null)
        {
            _instance = this;
            _nodes = FindObjectsByType<Node>(FindObjectsSortMode.None);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 指定した座標に最も近いノードを返す関数
    /// </summary>
    /// <param name="pos">近いノードがどこかを調べる対象の座標</param>
    /// <returns>指定した座標に最も近いノード</returns>
    public Node NearestNode(Vector3 pos)
    {
        Node result = null;
        float sqrtDistance = float.MaxValue;
        foreach (var node in _nodes)
        {
            var compareSqrtDistance = Vector3.SqrMagnitude(node.transform.position - pos);
            if (sqrtDistance > compareSqrtDistance)
            {
                result = node;
                sqrtDistance = compareSqrtDistance;
            }
        }
        return result;
    }

    /// <summary>
    /// 部分的A*アルゴリズム
    /// </summary>
    /// <param name="start">スタートノード</param>
    /// <param name="goal">ゴールノード</param>
    /// <returns>次に進むべきノード</returns>
    public Node PartlyAstar(Node start, Node goal)
    {
        Debug.Log($"{start.name} => {goal.name}");
        if (start == goal) return goal;
        Node result = null;
        float currentF = float.MaxValue;
        //隣接ノードを調べる
        foreach (var adj in start.Nodeds)
        {
            var newG = adj.Cost;
            var newH = Vector3.SqrMagnitude(goal.transform.position - adj.Node.transform.position);
            var newF = newG + newH;
            if (result) Debug.Log($"{adj.Node.name} : {newF}\n{result.name} : {currentF}");
            //現在の評価値より良いものが得られたら更新
            if (currentF > newF)
            {
                currentF = newF;
                result = adj.Node;
            }
        }
        return result;
    }

    //public Vector3[] Astar(Node start, Node goal, Vector3 startPos, Vector3 goalPos)
    //{
    //    Debug.Log($"{start.name} => {goal.name}");

    //}
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

    public TElement Dequeue()
    {
        if (_list.Count <= 0) throw new InvalidOperationException("PriorityQueue is empty");
        var index = _list.Count - 1;
        (_list[0], _list[index]) = (_list[index], _list[0]);
        var element = _list[index];
        _list.RemoveAt(index);
        DequeueHeapify();
        return element.element;
    }

    public TElement Peek()
    {
        if (_list.Count <= 0) throw new InvalidOperationException("PriorityQueue is empty");
        return _list[0].element;
    }

    void EnqueueHeapify()
    {
        int child = _list.Count - 1;
        while (true)
        {
            int parent = (child - 1) / 2;
            if (parent < 0) break;
            if (_list[parent].priority.CompareTo(_list[child].priority) < 0) break;
            (_list[parent], _list[child]) = (_list[child], _list[parent]);
            child = parent;
        }
    }

    void DequeueHeapify()
    {
        int parent = 0;
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
