using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killing : PlayerInteractable
{
    public override void OnHit(Collision2D hit, Player player)
    {
        Toolbox.GetInstance().GetManager<StatManager>().ReduceLife();
        Toolbox.GetInstance().GetManager<GameManager>().ShowHUD();
    }
}
