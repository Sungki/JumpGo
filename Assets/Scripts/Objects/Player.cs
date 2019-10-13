using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 move = Vector3.zero;
        move += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;

        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, 50f), ForceMode2D.Impulse);
        }
    }
}
