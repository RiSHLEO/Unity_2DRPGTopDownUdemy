using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int _moveX = Animator.StringToHash("MoveX");                  //safer way to type strings. just use string once here and variable can be resused
    private readonly int _moveY = Animator.StringToHash("MoveY");
    private readonly int _moving = Animator.StringToHash("Moving");
    private readonly int _dead = Animator.StringToHash("Dead");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMoveBoolTransition(bool value)
    {
        _animator.SetBool(_moving, value);
    }

    public void SetMoveAnimation(Vector2 dir)
    {
        _animator.SetFloat(_moveX, dir.x);
        _animator.SetFloat(_moveY, dir.y);
    }

    public void SetDeadAnimation()
    {
        _animator.SetTrigger(_dead);
    }
}
