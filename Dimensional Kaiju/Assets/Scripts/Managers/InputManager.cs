using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class InputManager : Singleton<InputManager>
{
    #region SO Inputs
    [SerializeField] private PlayerControlChannelSO playerInputs;
    #endregion
    
    #region Inputs & Actions
    private GameInputs _gameInput;
    private GameInputType _gameInputType;
    private Dictionary<GameInputType, InputActionMap> _actionMaps;
    #endregion

    protected override void Initialize()
    {
        if (_actionMaps == null)
        {
            _actionMaps = new Dictionary<GameInputType, InputActionMap>();
        }

        if (_gameInput == null)
        {
            _gameInput = new GameInputs();
            #region PlayerControls
            _gameInput.Player.Move.performed += (ctx) => playerInputs.HandleMovement(ctx.ReadValue<Vector2>());
            _gameInput.Player.Sprint.started += (ctx) => playerInputs.HandleSprint(true);
            _gameInput.Player.Sprint.canceled += (ctx) => playerInputs.HandleSprint(false);
            _actionMaps.Add(GameInputType.PlayerControl, _gameInput.Player);
            #endregion
        }
        _gameInput.Enable();
    }
}

public enum GameInputType { PlayerControl, MenuControl, DialogueControl }
