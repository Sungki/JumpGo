using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killing : PlayerInteractable
{
    public override void OnHit(Collision2D hit, Player player)
    {
        Destroy(player.gameObject);
    }
}
