using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class EndUIManager : MonoBehaviour
{
    public TMP_Text Total;

    private void Start()
    {
        Total.text = GameManager.instance.Score.ToString();
    }
}
