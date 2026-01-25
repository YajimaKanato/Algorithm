using UnityEngine;

public class LineFlow : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    Material _material;
    Vector2 _offset;
    float _offsetX;

    private void Awake()
    {
        _material = GetComponent<LineRenderer>().material;
        _offset = new Vector2(_offsetX, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _offsetX += Time.deltaTime * _speed;
        _offset.x = _offsetX;
        _material.mainTextureOffset = _offset;
    }

    public void LineSetting()
    {

    }
}
