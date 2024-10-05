using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private GroundDetector _groundDetector;

    private KeyCode _jumpKey = KeyCode.Space;
    private bool _isJump;

    public float DirectionX {  get; private set; }

    private void Awake()
    {
        _isJump = false;
    }

    private void Update()
    {
        DirectionX = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(_jumpKey) && _groundDetector.GetIsGround())
            _isJump = true;
    }

    public bool GetIsJump()
    {
        bool currentValue = _isJump;
        _isJump = false;

        return currentValue;
    }
}