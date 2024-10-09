using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private int _inputHorizontal = Animator.StringToHash("InputHorizontal");
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRunningAnimation(float inputHorizontal)
    {
        _animator.SetFloat(_inputHorizontal, Mathf.Abs(inputHorizontal));
    }
}