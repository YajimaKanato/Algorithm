using System.Collections.Generic;
using UnityEngine;

public class LineFlow : MonoBehaviour
{
    [SerializeField] GameObject _view;
    float _speed;
    LineRenderer _lineRenderer;
    Material _material;
    GameObject _target;
    Vector2 _offset;
    float _offsetX;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _material = _lineRenderer.material;
        _offset = new Vector2(_offsetX, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _offsetX += Time.deltaTime * _speed;
        _offset.x = _offsetX;
        _material.mainTextureOffset = _offset;
        if (_target) SetPosition();
    }

    public void LineSetting(List<Vector3> nodes, GameObject target, float speed)
    {
        if (nodes == null || nodes.Count == 0) return;
        if (nodes.Count == 1) nodes.Add(Vector3.zero);
        _lineRenderer.positionCount = nodes.Count;
        _lineRenderer.SetPositions(nodes.ToArray());
        _target = target;
        _speed = speed;
        SetPosition();
    }

    void SetPosition()
    {
        if (_lineRenderer.positionCount <= 0) return;
        _lineRenderer.SetPosition(0, _view.transform.position + Vector3.up / 2);
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _target.transform.position);
    }
}
