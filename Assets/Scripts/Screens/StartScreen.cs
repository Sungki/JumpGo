using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Toolbox.GetInstance().GetManager<LevelManager>().NextLevel();
        }
    }
}
