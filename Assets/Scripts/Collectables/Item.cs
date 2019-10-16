using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected float maxScale = 1;

    protected void SetColor(Color color)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    private void Update()
    {
        ScaleUpDown();
    }

    void ScaleUpDown()
    {
        transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
        if (transform.localScale.x >= maxScale) transform.localScale = Vector3.zero;
    }
}
