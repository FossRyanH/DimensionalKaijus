using UnityEngine;

public class AttackKaiju : StateMachine
{
        #region Components
    [Header("Componenets")]
    // public CharacterController Controller { get; private set; }
    public Rigidbody2D Rb2D { get; private set; }
    [field : SerializeField] public KaijuVariablesSO KaijuVariables { get; private set; }
    public Animator Animator { get; private set; }
    #endregion

    #region States
    #endregion

    #region Misc
    #endregion

    public AttackKaiju()
    {
        // 
    }

    void Awake()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Start()
    {
        // 
    }
}