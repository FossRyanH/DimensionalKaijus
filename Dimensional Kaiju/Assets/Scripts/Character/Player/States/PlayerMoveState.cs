using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    readonly int _runHash = Animator.StringToHash("Run");

    public PlayerMoveState(PlayerController player) : base(player)
    {
    }

    float _moveSpeed;

    public override void Enter()
    {
        base.Enter();
        _player.Animator.Play(_runHash);
    }

    public override void Update()
    {
        FacingDirection();

        if (_player.InputDir == Vector2.zero)
        {
            _player.ChangeState(_player.IdleState);
        }

        SetMovementSpeed();
    }

    public override void PhysicsUpdate()
    {
        UpdateAnimationDirection(_player.InputDir, _runHash);
        
        _player.Rb2D.linearVelocity = _player.InputDir * _moveSpeed * Time.fixedDeltaTime;

        if (_player.IsAttacking)
        {
            _player.ChangeState(_player.AttackState);
        }
    }

    void SetMovementSpeed()
    {
        if (_player.IsSprinting)
            _moveSpeed = _player.PlayerVariables.SprintSpeed;
        else
            _moveSpeed = _player.PlayerVariables.WalkSpeed;
    }
}