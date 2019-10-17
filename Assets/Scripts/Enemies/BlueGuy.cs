using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGuy : Enemy
{
    bool jumpFlag = false;

    private void Start()
    {
        speed = 1f;

        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.blue);
    }

    public override void Attack()
    {
        if(!jumpFlag)
        {
            jumpFlag = true;
            JumpAttack();
        }
    }

    public void JumpAttack()
    {
        rb.AddForce(new Vector2((target.x - transform.position.x)*5f, 40f), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpFlag = false;
        SetState(State.patrol);
    }
}
