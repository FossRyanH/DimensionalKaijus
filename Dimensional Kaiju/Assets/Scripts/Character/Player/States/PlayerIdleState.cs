using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // Animation non-sense goes here
    }

    public override void Update()
    {
        if (_inputDir != Vector2.zero)
        {
            _player.ChangeState(_player.MoveState);
        }
    }
}