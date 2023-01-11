using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : ItemBase
{
    public override void GetItem()
    {
        Player.CurrentBatteryState += Player.Data.BatteryEfficiency * 5;
        base.GetItem();
    }
}
