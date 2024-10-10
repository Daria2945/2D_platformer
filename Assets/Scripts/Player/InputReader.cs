using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private KeyCode _jumpKey = KeyCode.Space;
    private bool _isJump;

    public float DirectionX {  get; private set; }

    private void Update()
    {
        DirectionX = Input.GetAxis(Horizontal);

        if(Input.GetKeyDown(_jumpKey))
            _isJump= true;
    }

    public bool CanJump()
    {
        bool currentValue = _isJump;
        _isJump = false;

        return currentValue;
    }
}