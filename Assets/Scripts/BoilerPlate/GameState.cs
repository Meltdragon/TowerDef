using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : Singleton<GameState>
{
    [SerializeField] private bool testScene = false;
    private States currentState;

    public static States CurrentState { get => Instance.currentState; }

    private void Start()
    {
        if (testScene)
        {
            currentState = States.Game;
        }
        else
        {
            currentState = States.Menu;
        }
    }

    public static void TryToChangeState(States newState)
    {
        bool permissionGranted = false;

        if (CurrentState != newState)
        {
            permissionGranted = true;
        }

        switch (newState)
        {
            case States.Menu:
                {
                    if (permissionGranted)
                    {
                        //do something
                    }
                    break;
                }
            case States.Game:
                {
                    if (permissionGranted)
                    {
                        //do something
                    }
                    break;
                }
            case States.PreRound:
                {
                    if (permissionGranted)
                    {
                        //do something
                    }
                    break;
                }
            case States.StartRound:
                {
                    if (permissionGranted)
                    {
                        //do something
                    }
                    break;
                }
            case States.Pause:
                {
                    if (permissionGranted)
                    {
                        //do something
                    }
                    break;
                }
            case States.Quit:
                {
                    if (permissionGranted)
                    {
                        Application.Quit();
                    }
                    break;
                }
        }
    }
}

public enum States
{
    Menu,
    Game,
    PreRound,
    StartRound,
    Pause,
    Quit
}