using System;
using UnityEngine;

public class PlayerController : StateMachine
{
    #region InputSO's
    [field : SerializeField] public PlayerControlChannelSO PlayerInputs { get; private set; }
    #endregion
    
    #region Components
    [Header("Componenets")]
    public CharacterController Controller { get; private set; }
    [field : SerializeField] public PlayerVariablesSO PlayerVariables { get; private set; }
    public Animator Animator { get; private set; }
    #endregion

    #region States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion

    #region Misc
    public Vector2 InputDir { get; set; }
    #endregion

    public PlayerController()
    {
        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
    }

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
    }

    void Start()
    {
        Initialize(IdleState);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Update()
    {
        base.Update();
    }
}
