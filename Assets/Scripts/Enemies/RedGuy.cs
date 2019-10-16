using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGuy : Enemy
{
    private void Start()
    {
        speed = 1f;

        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.red);
    }

    public override void Attack()
    {
        DashAttack();
    }

    public void DashAttack()
    {
        transform.position = Vector3.Lerp(transform.position, target, 3 * Time.deltaTime);
        if (transform.position == target) SetState(State.patrol);
    }
}
