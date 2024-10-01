using UnityEngine;
using System;

public class RangedKaiju : StateMachine, IDamagable
{
     #region Components
    [Header("Componenets")]
    // public CharacterController Controller { get; private set; }
    public Rigidbody2D Rb2D { get; private set; }
    [field : SerializeField] public KaijuVariablesSO KaijuVariables { get; private set; }
    public Animator Animator { get; private set; }
    #endregion

    #region States
    public RangedKaijuIdleState IdleState;
    public RangedKaijuAttackState AttackState;
    #endregion

    #region Misc
    int _currentHealth;
    [SerializeField] public AudioClip BattleMusic;
    #endregion

    public RangedKaiju()
    {
        IdleState = new RangedKaijuIdleState(this);
        AttackState = new RangedKaijuAttackState(this);
    }

    void Awake()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Start()
    {
        Initialize(IdleState);
        _currentHealth = KaijuVariables.MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            var newMusic = FindFirstObjectByType<ForestMusicHandler>();
            GameManager.Instance.HandleStateChangeMusic(GameState.OverWorld);
            Destroy(this.gameObject, 0.5f);
        }
    }
}