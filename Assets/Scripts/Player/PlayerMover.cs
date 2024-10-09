using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _speedMove = 200f;
    [SerializeField] private float _jumpForce = 400f;

    private Rigidbody2D _rigidbody;
    private Transform _transform;

    private bool _isFacingRight = true;

    private void Awake()
    {
        _transform = transform;

        _transform.position = _startPosition.position;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce);
    }

    public void Move(float directionX)
    {
        _rigidbody.velocity = new Vector2(directionX * _speedMove * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    public void Rotate(float directionX)
    {
        float YAxisRotationAngle = 180f;

        if (directionX < 0 && _isFacingRight)
        {
            transform.Rotate(0, YAxisRotationAngle, 0);
            _isFacingRight = false;
        }

        if (directionX > 0 && _isFacingRight == false)
        {
            transform.Rotate(0, YAxisRotationAngle, 0);
            _isFacingRight = true;
        }
    }
}