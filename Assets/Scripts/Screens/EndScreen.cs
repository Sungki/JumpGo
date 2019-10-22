using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Toolbox.GetInstance().GetManager<GameManager>().InitText();
            Toolbox.GetInstance().GetManager<StatManager>().Init();
            Toolbox.GetInstance().GetManager<LevelManager>().Init();
            Toolbox.GetInstance().GetManager<LevelManager>().CurrentScreen();
        }
    }
}
