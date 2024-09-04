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
            // _gameInput.Player.Move.performed 
            #endregion
        }
    }
}

public enum GameInputType { PlayerControl, MenuControl, DialogueControl }
