﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    private float damping =2f;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, damping * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0, -10);
    }
}