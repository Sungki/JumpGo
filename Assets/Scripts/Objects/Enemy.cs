using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovableObject
{
    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;
    private float movementAI = 0;

    private void Start()
    {
        speed = 1f;
    }

    void Update()
    {
        velocity = Vector3.zero;
        MovementAI();
        transform.position += velocity * speed * Time.deltaTime;
    }

    void MovementAI()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            movementAI = Random.Range(1, 3);
        }

        if (movementAI == 1) velocity += Vector3.left;
        else if (movementAI == 2) velocity += Vector3.right;
    }
}
