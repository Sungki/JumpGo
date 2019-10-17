using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject
{
    Rigidbody2D rb;
    public float speedUp = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Toolbox.GetInstance().GetManager<GameManager>().SetRespawnPos(this.transform.position);
    }

    private void Update()
    {
        velocity = Vector3.zero;
        PlayerInput();
    }
    private void FixedUpdate()
    {
        transform.position += velocity * speed * speedUp * Time.deltaTime;
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

        if (Input.GetButtonDown("Jump")) Jump();
        if (Input.GetKey("escape")) Application.Quit();
    }
    void Jump()
    {
        transform.parent = null;
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, 50f), ForceMode2D.Impulse);
    }

    public void SpeedUp(float up)
    {
        speedUp = up;
        Invoke("RemoveSpeedUp", 5.0f);
    }

    void RemoveSpeedUp()
    {
        speedUp = 1.0f;
    }
}
