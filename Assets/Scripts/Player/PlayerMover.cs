using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _speedMove = 2.5f;
    [SerializeField] private float _jumpForce = 450f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _sprite;

    private bool _isFacingRight = true;

    private void Awake()
    {
        transform.position = _startPosition.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void Jump()
    {
        Vector2 forse = new(0, _jumpForce);

        _rigidbody.AddForce(forse);
    }

    public void Move(float directionX)
    {
        Vector3 direction = new(directionX * _speedMove * Time.fixedDeltaTime, 0, 0);

        transform.position += direction;
    }

    public void Rotate(float directionX)
    {
        _sprite.flipX = directionX < 0 && _isFacingRight;
    }
}