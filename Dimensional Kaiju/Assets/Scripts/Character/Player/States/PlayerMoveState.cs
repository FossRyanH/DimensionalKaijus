using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    readonly int _runHash = Animator.StringToHash("RunTree");

    Vector2 _smoothedInputDir;
    float _smoothFactor = 0.2f;

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
        if (_player.InputDir == Vector2.zero)
        {
            _player.ChangeState(_player.IdleState);
        }

        SetMovementSpeed();
        _smoothedInputDir = Vector2.Lerp(_smoothedInputDir, _player.InputDir * _moveSpeed, _smoothFactor);
    }

    public override void PhysicsUpdate()
    {
        UpdateMoveAnimationDirection(_player.InputDir, _runHash);
        _player.Controller.Move(_smoothedInputDir * Time.fixedDeltaTime);
    }

    void SetMovementSpeed()
    {
        if (_isSprinting)
            _moveSpeed = _player.PlayerVariables.SprintSpeed;
        else
            _moveSpeed = _player.PlayerVariables.WalkSpeed;
    }
}