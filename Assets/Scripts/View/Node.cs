using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] AdjNode[] _nodes;

    public AdjNode[] Nodeds => _nodes;
}

[System.Serializable]
public class AdjNode
{
    [SerializeField] Node _node;
    [SerializeField] int _cost;

    public Node Node => _node;
    public int Cost => _cost;
}
