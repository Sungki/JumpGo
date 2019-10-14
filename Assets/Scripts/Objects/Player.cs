using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject
{
    private void Update()
    {
        velocity = Vector3.zero;
        PlayerInput();
        transform.position += velocity * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInteractable pi = collision.gameObject.GetComponent<PlayerInteractable>();
        if (pi)
        {
            pi.OnHit(collision, this);
        }
    }

    void PlayerInput()
    {
        velocity += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKey("escape")) Application.Quit();
    }
    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, 50f), ForceMode2D.Impulse);
    }
}
