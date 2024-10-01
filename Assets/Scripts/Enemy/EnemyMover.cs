using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _route;

    private SpriteRenderer _sprite;
    private Transform[] _wayponints;
    private int _currentPoint;

    private void Awake()
    {
        _wayponints = GetRoute();

        _currentPoint = 0;
        transform.position = _wayponints[_currentPoint].position;
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void Move()
    {
        if (transform.position == _wayponints[_currentPoint].position)
            _currentPoint = ++_currentPoint % _wayponints.Length;

        transform.position = Vector3.MoveTowards(transform.position, _wayponints[_currentPoint].position, _speed * Time.deltaTime);
        transform.LookAt(transform.position);
        
    }

    public void Rotation()
    {
        _sprite.flipX = _wayponints[_currentPoint].position.x > transform.position.x;
    }

    private Transform[] GetRoute()
    {
        Transform[] waypoints = new Transform[_route.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = _route.GetChild(i).GetComponent<Transform>();
        }

        return waypoints;
    }
}