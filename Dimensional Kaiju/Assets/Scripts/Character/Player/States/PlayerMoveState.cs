using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerController player) : base(player)
    {
    }

    float _moveSpeed;

    public override void Enter()
    {
        base.Enter();
        // More animation shit goes here.
    }

    public override void Update()
    {
        SetMovementSpeed();
        if (_inputDir == Vector2.zero)
        {
            _player.ChangeState(_player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        _player.Rb2d.linearVelocity = _inputDir * _moveSpeed * Time.fixedDeltaTime;
    }

    void SetMovementSpeed()
    {
        if (!_isSprinting)
            _moveSpeed = _player.PlayerVariables.WalkSpeed;
        else
            _moveSpeed = _player.PlayerVariables.SprintSpeed;
    }
}