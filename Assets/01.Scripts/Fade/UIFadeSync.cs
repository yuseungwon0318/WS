using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFadeSync : MonoBehaviour
{
    [SerializeField]
    private Image syncTarget;
    public Image SyncTarget
    {
        get => syncTarget;
    }
    private TextMeshProUGUI text;
    private Color color;
    private Image img;
    public Color colorTemp;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        img = GetComponent<Image>();
        if (text != null) colorTemp = text.color;
        else if (img != null) colorTemp = img.color;
        else Debug.LogError("what r u doing");
    }
    private void Update()
    {
        colorTemp.a = syncTarget.color.a;
        if(text != null)
        {
            text.color = colorTemp;
        }
        else if(img != null) 
        {
            img.color = colorTemp;
        }
    }
}
