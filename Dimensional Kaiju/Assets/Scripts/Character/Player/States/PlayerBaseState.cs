using UnityEngine;
using System;

public class PlayerBaseState : IState, IPlayerControlListener
{
    protected PlayerController _player;
    protected bool _isSprinting;
    protected Vector2 _inputDir;

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

    public void Interact() {}

    public void Movement(Vector2 movement)
    {
        _inputDir = movement;
        _inputDir.Normalize();
        Debug.Log(_inputDir);
    }

    public void OpenMenu() {}

    public void Sprint(bool isSprinting) 
    {
        _isSprinting = isSprinting;
    }
}