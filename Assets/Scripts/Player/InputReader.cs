using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private GroundDetector _groundDetector;
    private bool _isJump;

    public float DirectionX {  get; private set; }

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _isJump = false;
    }

    private void Update()
    {
        DirectionX = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space) && _groundDetector.IsGround)
            _isJump = true;
    }

    public bool GetIsJump()
    {
        bool currentValue = _isJump;
        _isJump = false;

        return currentValue;
    }
}