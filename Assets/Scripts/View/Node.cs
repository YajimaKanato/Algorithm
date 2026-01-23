using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] AdjNode[] _nodes;

    float _g;
    float _h;
    float _f;

    Node _parent;

    public void CostUpdate(float g, float h, float f, Node parent)
    {
        _g = g;
        _h = h;
        _f = f;
        _parent = parent;
    }
}

[System.Serializable]
public class AdjNode
{
    [SerializeField] Node _node;
    [SerializeField] int _cost;
}
