using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private void Start()
    {
        Toolbox.GetInstance().GetManager<GameManager>().ShowSummary();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Toolbox.GetInstance().GetManager<GameManager>().InitText();
            Toolbox.GetInstance().GetManager<StatManager>().Init();
            Toolbox.GetInstance().GetManager<LevelManager>().Init();
            Toolbox.GetInstance().GetManager<LevelManager>().CurrentScreen();
        }
    }
}
