using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UIFade : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Color color;

    [SerializeField]
    private float fadeTime;
    public float FadeTime
    {
        get => fadeTime;
    }

    private Image img;

    [SerializeField]
    private bool fadeIn;
    
    [SerializeField]
    private bool fadeOut;

    [SerializeField]
    private bool usingFunc = false;

    [SerializeField]
    private float alpha = 1f;

    void Start()
    {
        
        text = GetComponent<TextMeshProUGUI>();
        img = GetComponent<Image>();
        if(text != null)
        {
            color = text.color;
        }
        else if(img != null)
        {
            color = img.color;
        }

        if (usingFunc) return;

        if(fadeIn && fadeOut)
        {
            FadeInFadeOut();
        }
        else if(!fadeIn && fadeOut)
        {
            FadeOut();
        }
        else if(fadeIn && !fadeOut)
        {
            FadeIn();
        }
        
    }

    void Update()
    {
        
        if (text != null)
        {
            text.color = color;
        }
        else if (img != null)
        {
            img.color = color;
        }
    }

    public void FadeOut()
    {
        if(!fadeOut)
        {
            Debug.LogError("Please use other fade option");
        }
        DOTween.To(() => color.a, x => color.a = x, 0, fadeTime).SetUpdate(true);
    }
    public void FadeIn()
    {
        if (!fadeIn)
        {
            Debug.LogError("Please use other fade option");
        }
        DOTween.To(() => color.a, x => color.a = x, alpha, fadeTime).SetUpdate(true);
    }
    public void FadeInFadeOut()
    {
        if (!(fadeIn && fadeOut))
        {
            Debug.LogError("Please use other fade option");
        }
        DOTween.To(() => color.a, x => color.a = x, 0, fadeTime).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
    }
}
