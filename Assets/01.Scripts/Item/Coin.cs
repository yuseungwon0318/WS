using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ItemBase
{
    public int CoinValue = 1;
    public override void GetItem()
    {
        GameManager.instance.GetCoin(CoinValue);
        base.GetItem();
    }

        
}
