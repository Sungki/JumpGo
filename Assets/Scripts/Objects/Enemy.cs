using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovableObject, IFSM
{
    public enum State
    {
        patrol,
        chase,
        attack
    }

    [SerializeField] private State curr = State.patrol;
    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;
    protected float movementAI = 0;
    protected Vector3 target = Vector3.zero;

    protected GameObject player;
    protected Rigidbody2D rb;

    void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = Vector3.zero;

        switch(curr)
        {
            case State.patrol:
                Patrol();
                break;
            case State.chase:
                Chase();
                break;
            case State.attack:
                Attack();
                break;
        }
    }

    private void FixedUpdate()
    {
        transform.position += velocity * speed * Time.deltaTime;
    }

    protected void SetState(State next)
    {
        curr = next;
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

    public void Patrol()
    {
        MovementAI();

        if (player && (Vector2.Distance(player.transform.position, transform.position) < 4f))
            SetState(State.chase);
    }

    public void Chase()
    {
        if (player)
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 4f)
                SetState(State.patrol);

            velocity = player.transform.position - transform.position;
            velocity.y = 0f;
            velocity.z = 0f;

            if (Vector2.Distance(player.transform.position, transform.position) < 2f)
            {
                target = player.transform.position;
                SetState(State.attack);
            }
        }
    }

    public virtual void Attack() {}
}
