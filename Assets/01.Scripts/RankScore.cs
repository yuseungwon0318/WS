using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankScore : MonoBehaviour
{
    string FindUniqueID()
    {
        string id;
        id = "kick" + UnityEngine.Random.Range(0, 1000000);

        return id;
    }
}
