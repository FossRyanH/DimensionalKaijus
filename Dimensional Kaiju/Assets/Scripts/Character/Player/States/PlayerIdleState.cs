using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    readonly int _idleHash = Animator.StringToHash("Idle");
    readonly int _weaponIdle = Animator.StringToHash("WeaponIdle");

    public PlayerIdleState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // Animation non-sense goes here
        _player.Animator.PlayInFixedTime(_idleHash);
        _player.WeaponAnimator.CrossFadeInFixedTime(_weaponIdle, 0.2f);
    }

    public override void Update()
    {
        UpdateAnimationDirection(_lastInput, _idleHash);
        if (_player.InputDir != Vector2.zero)
        {
            _player.ChangeState(_player.MoveState);
        }
        
        if (_player.IsAttacking)
            _player.ChangeState(_player.AttackState);
        else
            return;

        if (_player.IsUsingSkill)
            _player.ChangeState(_player.SwordSkill);
        else
            return;
    }

    public override void Exit()
    {
        base.Exit();
    }
}