using UnityEngine;
using System;

public class PlayerBaseState : IState, IPlayerControlListener
{
    protected PlayerController _player;
    protected bool _isSprinting;
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
    }

        void DeregisterListeners()
    {
        _player.PlayerInputs.Movement -= Movement;
        _player.PlayerInputs.Sprint -= Sprint;
    }

    protected void UpdateMoveAnimationDirection(Vector2 direction, int animationHash)
    {
        if (Mathf.Abs(direction.x) > 0f)
        {
            _player.Animator.Play(animationHash);
            _player.Animator.SetFloat("xInput", _player.InputDir.x);
            _player.Animator.SetFloat("yInput", 0f);
        }
        else if (Mathf.Abs(direction.y) > 0f)
        {
            _player.Animator.Play(animationHash);
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
        _isSprinting = isSprinting;
    }
}