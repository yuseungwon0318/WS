using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankUI : MonoBehaviour
{
    public void clickRank()
    {
        GPGSBinder.Inst.ShowAllLeaderboardUI();
    }
}
