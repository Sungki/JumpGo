using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGuy : Enemy
{
    private void Start()
    {
        speed = 1f;

        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.blue);
    }
}
