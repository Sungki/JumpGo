using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shimmy : MonoBehaviour
{
    public float distance = 2.5f;

    private Vector3 originalPosition;

    void Start()
    {
        this.originalPosition = this.transform.position;
    }

    void Update()
    {
        this.transform.position = this.originalPosition + this.transform.right * this.distance * Mathf.Sin(Time.time);
    }
}
