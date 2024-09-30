using UnityEngine;
using System;

public class PlayerBaseState : IState, IPlayerControlListener
{
    protected PlayerController _player;
    protected Vector2 _lastInput;

    public PlayerBaseState(PlayerController player)
    {
        _player = player;
    }

    public virtual void Enter() 
    {
        RegisterListeners();
    }

    public virtual void Exit() 
    {
        DeregisterListeners();
    }

    public virtual void Update() {}

    public virtual void PhysicsUpdate() {}

    void RegisterListeners()
    {
        _player.PlayerInputs.Movement += Movement;
        _player.PlayerInputs.Sprint += Sprint;
        _player.PlayerInputs.Attack += Attack;
        _player.PlayerInputs.Skill += Skill;
    }

        void DeregisterListeners()
    {
        _player.PlayerInputs.Movement -= Movement;
        _player.PlayerInputs.Sprint -= Sprint;
        _player.PlayerInputs.Attack -= Attack;
        _player.PlayerInputs.Skill -= Skill;
    }

    protected void FacingDirection()
    {
        bool isMovinghorizontal = Mathf.Abs(_player.Rb2D.linearVelocity.x) > Mathf.Epsilon;
        if (isMovinghorizontal)
        {
            _player.transform.localScale = new Vector2(Mathf.Sign(_player.Rb2D.linearVelocity.x), 1f);
        }
    }

    protected void UpdateAnimationDirection(Vector2 direction, int animationHash)
    {
        if (Mathf.Abs(direction.x) > 0f)
        {
            _player.Animator.PlayInFixedTime(animationHash);
            _player.Animator.SetFloat("xInput", _player.InputDir.x);
            _player.Animator.SetFloat("yInput", 0f);
        }
        else if (Mathf.Abs(direction.y) > 0f)
        {
            _player.Animator.PlayInFixedTime(animationHash);
            _player.Animator.SetFloat("yInput", _player.InputDir.y);
            _player.Animator.SetFloat("xInput", 0f);
        }
    }

    protected void SetLastDirectionInput()
    {
        if (_player.InputDir.x != 0f)
        {
            _lastInput = new Vector2(Mathf.Sign(_player.InputDir.x), 0f);
        }
        else if (_player.InputDir.y != 0f)
        {
            _lastInput = new Vector2(0f, Mathf.Sign(_player.InputDir.y));
        }
    }

    public void Interact() {}

    public void Movement(Vector2 movement)
    {
        _player.InputDir = movement;
        _player.InputDir.Normalize();
    }

    public void OpenMenu() {}

    public void Sprint(bool isSprinting) 
    {
        _player.IsSprinting = isSprinting;
    }

    public void Attack(bool isAttacking)
    {
        _player.IsAttacking = isAttacking;
    }

    public void Skill(bool isUsingSkill)
    {
        _player.IsUsingSkill = isUsingSkill;
    }
}