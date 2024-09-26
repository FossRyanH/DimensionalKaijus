using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    readonly int _idleHash = Animator.StringToHash("IdleTree");

    public PlayerIdleState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.Animator.SetBool("isIdle", true);
        // Animation non-sense goes here
        _player.Animator.PlayInFixedTime(_idleHash);
        Debug.Log("Entered Idle");
    }

    public override void Update()
    {
        UpdateMoveAnimationDirection(_lastInput, _idleHash);
        if (_player.InputDir != Vector2.zero)
        {
            _player.ChangeState(_player.MoveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        _player.Animator.SetBool("isIdle", false);
    }
}