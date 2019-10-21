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
        Vector3 temp = transform.position;
        transform.position = Vector3.Lerp(transform.position, target, 3 * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, temp.y, temp.z);

        if (transform.position.x == target.x) SetState(State.patrol);
    }
}
