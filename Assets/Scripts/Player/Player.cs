using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(InputReader), typeof(PlayerAnimator))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private InputReader _inputReader;
    private Wallet _wallet;

    private PlayerAnimator _animation;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _inputReader = GetComponent<InputReader>();
        _animation = GetComponent<PlayerAnimator>();
        _wallet = GetComponent<Wallet>();
    }

    private void Update()
    {
        _animation.PlayRunningAnimation(_inputReader.DirectionX);
    }

    private void FixedUpdate()
    {
        if (_inputReader.DirectionX != 0)
        {
            _mover.Move(_inputReader.DirectionX);
            _mover.Rotate(_inputReader.DirectionX);
        }

        if (_inputReader.GetIsJump())
        {
            _mover.Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            _wallet.CollectCoin();
        }
    }
}