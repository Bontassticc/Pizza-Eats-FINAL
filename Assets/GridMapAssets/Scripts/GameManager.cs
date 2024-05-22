using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.Player1Turn);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Player1Turn:

                break;
            //case GameState.GenerateRandomValues:
            // break;
            case GameState.Player2Turn:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnStateChanged?.Invoke(newState);
    }

    public enum GameState
    {
        Player1Turn = 0 ,
        //GenerateRandomValues,
        Player2Turn = 1,
        Win,
        Lose
    }
}
