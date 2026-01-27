using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] AdjNode[] _nodes;
    [SerializeField] NodeType _nodeType;

    public AdjNode[] Nodeds => _nodes;
    public NodeType NodeType => _nodeType;
}

[System.Serializable]
public class AdjNode
{
    [SerializeField] Node _node;
    [SerializeField] int _cost;

    public Node Node => _node;
    public int Cost => _cost;
}

public enum NodeType
{
    [InspectorName("道")] Road
}
