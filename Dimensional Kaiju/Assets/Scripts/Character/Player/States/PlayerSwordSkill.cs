using UnityEngine;
using System.Collections;

public class PlayerSwordSkill : PlayerBaseState
{
    public PlayerSwordSkill(PlayerController player) : base(player)
    {
    }

    readonly int _skillHash = Animator.StringToHash("SwordSkill");
    float _timer = 1.4f;


    public override void Enter()
    {
        base.Enter();
        _player.Animator.PlayInFixedTime(_skillHash);
        _player.StartCoroutine(ResetState());
    }

    public override void Exit()
    {
        base.Exit();
        _player.IsUsingSkill = false;
    }

    IEnumerator ResetState()
    {
        yield return new WaitForSeconds(_timer);
        _player.ChangeState(_player.IdleState);
    }
}