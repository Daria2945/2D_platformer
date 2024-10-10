using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(InputReader), typeof(PlayerAnimator))]
[RequireComponent(typeof(Wallet), typeof(CollisionDetector))]
public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;

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
    }

    private void FixedUpdate()
    {
        if (_inputReader.DirectionX != 0)
        {
            _mover.Move(_inputReader.DirectionX);
            _mover.Rotate(_inputReader.DirectionX);
        }

        if (_inputReader.CanJump() && _groundDetector.IsGrounded)
        {
            _mover.Jump();
        }
    }

    private void OnEnable()
    {
        _collisionDetector.CoinFound += CollectCoin;
    }

    private void OnDisable()
    {
        _collisionDetector.CoinFound -= CollectCoin;
    }

    private void CollectCoin(Coin coin)
    {
        coin.Hide();
        _wallet.CollectCoin();
    }
}