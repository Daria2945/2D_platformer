using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(InputReader), typeof(PlayerAnimator))]
[RequireComponent(typeof(Wallet), typeof(CollisionDetector))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private InputReader _inputReader;
    private Wallet _wallet;
    private CollisionDetector _collisionDetector;

    private PlayerAnimator _animation;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _inputReader = GetComponent<InputReader>();
        _animation = GetComponent<PlayerAnimator>();
        _wallet = GetComponent<Wallet>();
        _collisionDetector = GetComponent<CollisionDetector>();
    }

    private void Update()
    {
        _animation.PlayRunningAnimation(_inputReader.DirectionX);

        if (_collisionDetector.IsCoinFound)
            CollectCoin();
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

    private void CollectCoin()
    {
        _wallet.CollectCoin();
    }
}