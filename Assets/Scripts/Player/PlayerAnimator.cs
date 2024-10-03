using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private static int s_inputHorizontal = Animator.StringToHash("InputHorizontal");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRunningAnimation(float inputHorizontal)
    {
        _animator.SetFloat(s_inputHorizontal, Mathf.Abs(inputHorizontal));
    }
}