using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 50), "Pause");

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 100), "Do you want to continue?"))
        {
            transform.parent.GetComponentInChildren<LevelManager>().NextLevel();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 300, 100), "Do you want to quit?"))
        {
            transform.parent.GetComponentInChildren<LevelManager>().Init();
            transform.parent.GetComponentInChildren<LevelManager>().GotoScreen("StartScreen");
        }
    }
}
