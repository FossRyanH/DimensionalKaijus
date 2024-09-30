using System;
using UnityEngine;

public class PlayerController : StateMachine
{
    #region InputSO's
    [field : SerializeField] public PlayerControlChannelSO PlayerInputs { get; private set; }
    #endregion
    
    #region Components
    [Header("Componenets")]
    // public CharacterController Controller { get; private set; }
    public Rigidbody2D Rb2D { get; private set; }
    [field : SerializeField] public PlayerVariablesSO PlayerVariables { get; private set; }
    public Animator Animator { get; private set; }
    [field : SerializeField] public Animator WeaponAnimator { get; private set; }
    [field : SerializeField] public GameObject WeaponTrail { get; private set; }
    #endregion

    #region States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    public PlayerSwordSkill SwordSkill { get; private set; }
    #endregion

    #region Misc
    public Vector2 InputDir { get; set; }
    public bool IsAttacking { get; set; } = false;
    public bool IsUsingSkill { get; set; } = false;
    public bool IsSprinting { get; set; } = false;
    #endregion

    public PlayerController()
    {
        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
        AttackState =  new PlayerAttackState(this);
        SwordSkill = new PlayerSwordSkill(this);
    }

    private void Awake()
    {
        // Controller = GetComponent<CharacterController>();
        Rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Start()
    {
        Initialize(IdleState);
        WeaponTrail.SetActive(false);
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
