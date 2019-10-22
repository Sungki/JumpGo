using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoin : PlayerInteractable
{
    public override void OnHit(Collision2D hit, Player player)
    {
        Toolbox.GetInstance().GetManager<StatManager>().AddCoin();
        Toolbox.GetInstance().GetManager<GameManager>().ShowHUD();

        Destroy(this.gameObject);
    }
}
