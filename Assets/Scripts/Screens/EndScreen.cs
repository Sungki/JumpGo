using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Toolbox.GetInstance().GetManager<LevelManager>().NextLevel();
        }
    }
}
