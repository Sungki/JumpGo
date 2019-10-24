using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    GameObject target;
    private float damping =2f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, damping * Time.deltaTime);
            float temp = Mathf.Clamp(transform.position.x, 0, 33f);
            transform.position = new Vector3(temp, 0, -10);
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
