using System;
using UnityEngine;

public class PlayerController : StateMachine
{
    #region InputSO's
    [field : SerializeField] public PlayerControlChannelSO PlayerInputs { get; private set; }
    #endregion
    
    #region Components
    [Header("Componenets")]
    public Rigidbody2D Rb2d { get; private set; }
    [field : SerializeField] public PlayerVariablesSO PlayerVariables;
    #endregion

    #region States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion

    public PlayerController()
    {
        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
    }

    private void Awake()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Initialize(IdleState);
    }
}
