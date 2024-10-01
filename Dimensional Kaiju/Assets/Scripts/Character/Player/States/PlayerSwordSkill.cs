using UnityEngine;
using System.Collections;

public class PlayerSwordSkill : PlayerBaseState
{
    float _moveSpeed;
    float _healAmount;

    public PlayerSwordSkill(PlayerController player) : base(player)
    {
    }

    readonly int _skillHash = Animator.StringToHash("WeaponAttack");
    float _timer = 1.5f;


    public override void Enter()
    {
        base.Enter();
        _moveSpeed = _player.PlayerVariables.WalkSpeed;
        _player.WeaponAnimator.PlayInFixedTime(_skillHash);
        _player.WeaponTrail.SetActive(true);
        _player.StartCoroutine(ResetState());
    }

    public override void PhysicsUpdate()
    {
        _player.Rb2D.linearVelocity = _player.InputDir * _moveSpeed * Time.fixedDeltaTime;
    }

    public override void Exit()
    {
        base.Exit();
        _player.WeaponTrail.SetActive(false);
        _player.IsUsingSkill = false;
    }

    IEnumerator ResetState()
    {
        yield return new WaitForSeconds(_timer);
        _player.ChangeState(_player.IdleState);
    }
}