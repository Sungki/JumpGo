using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBridge : PlayerInteractable
{
    public override void OnHit(Collision2D hit, Player player)
    {
        player.transform.parent = this.transform;
    }
}
