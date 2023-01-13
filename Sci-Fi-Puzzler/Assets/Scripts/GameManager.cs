using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { SETUP, GAME_START, PLAYING, PAUSED, GAME_OVER };
    private GameState state = GameState.GAME_START;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GameState.SETUP:
                break;
            case GameState.GAME_START:
                break;
            case GameState.PLAYING:
                break;
            case GameState.PAUSED:
                break;
            case GameState.GAME_OVER:
                break;
            default:
                break;
        }
    }

    public void SetGameState(GameState game) {
        this.state = game;
    }
}
