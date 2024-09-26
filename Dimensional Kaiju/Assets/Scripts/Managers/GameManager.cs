using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState CurrentGameState { get; private set; }
}

public enum GameState { OverWorld, Menu, Battle }
