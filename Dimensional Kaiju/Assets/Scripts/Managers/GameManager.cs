using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState CurrentGameState { get; set; }

    protected override void Initialize()
    {
        // This line is for debugging.
        CurrentGameState = GameState.OverWorld;
    }

    void Update()
    {
        if (CurrentGameState == GameState.OverWorld)
        {
            InputManager.Instance.DisableInputType(GameInputType.MenuControl);
            InputManager.Instance.DisableInputType(GameInputType.DialogueControl);
            InputManager.Instance.EnableInputType(GameInputType.PlayerControl);
        }
        else if (CurrentGameState == GameState.Menu)
        {
            InputManager.Instance.DisableInputType(GameInputType.DialogueControl);
            InputManager.Instance.DisableInputType(GameInputType.PlayerControl);
            InputManager.Instance.EnableInputType(GameInputType.MenuControl);
        }
        else
        {
            InputManager.Instance.DisableInputType(GameInputType.MenuControl);
            InputManager.Instance.DisableInputType(GameInputType.DialogueControl);
            InputManager.Instance.EnableInputType(GameInputType.PlayerControl);
        }
    }

    public void HandleStateChangeMusic(GameState gameState)
    {
        CurrentGameState = gameState;

        var forestMusic = FindFirstObjectByType<ForestMusicHandler>().forestMusicBGM;

        if (gameState == GameState.OverWorld)
        {
            MusicManager.Instance.StopMusic();
            MusicManager.Instance.PlayMusic(forestMusic, true);
        }
        else if (gameState == GameState.Battle)
        {
            MusicManager.Instance.StopMusic();
            MusicManager.Instance.PlayMusic(MusicManager.Instance.BattleMusic, true);
        }
        else if (CurrentGameState == GameState.Menu)
        {
            MusicManager.Instance.StopMusic();
            MusicManager.Instance.PlayMusic(MusicManager.Instance.MenuMusic, true);
        }
    }
}

public enum GameState { OverWorld, Menu, Battle }
