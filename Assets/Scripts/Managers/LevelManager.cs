using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private SceneState currentState = 0;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        currentState = SceneState.StartScreen;
    }

    public void NextLevel()
    {
        if (currentState == SceneState.SummaryScreen) Init();
        else
        {
            currentState++;
        }
        SceneManager.LoadScene(currentState.ToString());
    }

    public void CurrentScreen()
    {
        SceneManager.LoadScene(currentState.ToString());
    }

    public void GotoScreen(string screen)
    {
        SceneManager.LoadScene(screen);
    }
}
