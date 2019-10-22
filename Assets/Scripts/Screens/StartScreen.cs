using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKey("escape")) Application.Quit();
            Toolbox.GetInstance().GetManager<LevelManager>().NextLevel();
            Toolbox.GetInstance().GetManager<GameManager>().InitText();
        }
    }
}
