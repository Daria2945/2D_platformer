using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRunningAnimation(float inputHorizontal)
    {
        _animator.SetFloat("InputHorizontal", Mathf.Abs(inputHorizontal));
    }
}