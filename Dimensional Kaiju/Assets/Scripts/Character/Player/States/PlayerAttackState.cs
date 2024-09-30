using System.Collections;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    float _moveSpeed;
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
        _moveSpeed = _player.PlayerVariables.WalkSpeed;
    }

    public override void PhysicsUpdate()
    {
        _player.Rb2D.linearVelocity = _player.InputDir * _moveSpeed * Time.fixedDeltaTime;
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