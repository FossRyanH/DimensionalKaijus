using System.Collections;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    readonly int _attackHash = Animator.StringToHash("WeaponAttack");
    float _timer = 0.8f;

    public PlayerAttackState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.WeaponAnimator.PlayInFixedTime(_attackHash);
        _player.WeaponTrail.SetActive(true);
        _player.StartCoroutine(ResetState());
    }

    public override void Exit()
    {
        base.Exit();
        _player.WeaponTrail.SetActive(false);
        _player.IsAttacking = false;
    }

    IEnumerator ResetState()
    {
        yield return new WaitForSeconds(_timer);
        _player.ChangeState(_player.IdleState);
    }
}