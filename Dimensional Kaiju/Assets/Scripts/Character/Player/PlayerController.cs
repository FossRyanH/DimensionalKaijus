using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerControlListener
{
    #region InputSO's
    [SerializeField] private PlayerControlChannelSO playerInputs;
    #endregion
    
    #region Components
    [Header("Componenets")]
    private Rigidbody2D _rb2d;
    [SerializeField] private PlayerVariablesSO playerVariables;
    #endregion

    private Vector2 _inputDir;
    private float _moveSpeed;
    bool _isSprinting = false;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        RegisterListeners();
    }

    private void Start()
    {
        _moveSpeed = playerVariables.WalkSpeed;
    }

    private void FixedUpdate()
    {
        _rb2d.linearVelocity = _inputDir * _moveSpeed * Time.fixedDeltaTime;
    }

    private void Update()
    {
        SetMovementSpeed();
    }

    private void OnDisable()
    {
        DeregisterListeners();
    }

    void RegisterListeners()
    {
        playerInputs.Movement += Movement;
        playerInputs.Sprint += Sprint;
    }

    void DeregisterListeners()
    {
        playerInputs.Movement -= Movement;
        playerInputs.Sprint -= Sprint;
    }

    public void Movement(Vector2 movement)
    {
        _inputDir = movement;
        _inputDir.Normalize();
        Debug.Log(_inputDir);
    }

    void SetMovementSpeed()
    {
        if (!_isSprinting)
            _moveSpeed = playerVariables.WalkSpeed;
        else
            _moveSpeed = playerVariables.SprintSpeed;
    }

    public void Interact() {}

    public void Cancel() {}

    public void OpenMenu() {}

    public void Sprint(bool isSprinting)
    {
        _isSprinting = isSprinting;
    }
}
