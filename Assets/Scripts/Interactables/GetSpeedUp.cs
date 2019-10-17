using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeedUp : PlayerInteractable
{
    public override void OnHit(Collision2D hit, Player player)
    {
        player.SpeedUp(1.8f);
        Destroy(this.gameObject);
    }
}
