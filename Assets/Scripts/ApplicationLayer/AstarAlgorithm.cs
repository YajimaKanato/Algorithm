using UnityEngine;

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
}
