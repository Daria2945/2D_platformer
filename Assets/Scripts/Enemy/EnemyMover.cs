using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform[] _route;

    private Transform _transform;

    private int _currentPoint;
    private bool _isFacingRight;

    private void Awake()
    {
        _transform = transform;

        _currentPoint = 0;
        _transform.position = _route[_currentPoint].position;

        _isFacingRight = false;
    }

    public void Move()
    {
        if (_transform.position == _route[_currentPoint].position)
            _currentPoint = ++_currentPoint % _route.Length;

        _transform.position = Vector3.MoveTowards(_transform.position, _route[_currentPoint].position, _speed * Time.deltaTime);
    }

    public void Rotate()
    {
        float YAxisRotationAngle = 180f;

        if (_route[_currentPoint].position.x < _transform.position.x && _isFacingRight)
        {
            transform.Rotate(0, YAxisRotationAngle, 0);
            _isFacingRight = false;
        }

        if (_route[_currentPoint].position.x > _transform.position.x && _isFacingRight == false)
        {
            transform.Rotate(0, YAxisRotationAngle, 0);
            _isFacingRight = true;
        }
    }
}