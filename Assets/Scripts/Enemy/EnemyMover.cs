using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform[] _route;

    private SpriteRenderer _sprite;
    private int _currentPoint;

    private void Awake()
    {
        _currentPoint = 0;
        transform.position = _route[_currentPoint].position;
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void Move()
    {
        if (transform.position == _route[_currentPoint].position)
            _currentPoint = ++_currentPoint % _route.Length;

        transform.position = Vector3.MoveTowards(transform.position, _route[_currentPoint].position, _speed * Time.deltaTime);
        transform.LookAt(transform.position);
        
    }

    public void Rotation()
    {
        _sprite.flipX = _route[_currentPoint].position.x > transform.position.x;
    }
}