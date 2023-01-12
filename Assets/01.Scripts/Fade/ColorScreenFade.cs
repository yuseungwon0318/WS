using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using DG.Tweening.Core;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class ColorScreenFade : MonoBehaviour
{

    [SerializeField]
    [ColorUsageAttribute(false, true)]   
    private Color targetColor;
    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float maxRadius;
    [SerializeField]
    private float time;

    private VolumeProfile volumeProfile;
    [SerializeField]
    private Volume volume;

    ColorAdjustments colorEffect;
    DepthOfField dof;

    private void Awake()
    {
       volumeProfile = volume.profile;

       volumeProfile.TryGet(out colorEffect);
       volumeProfile.TryGet(out dof);
        
    }
    
    public void ColorScreen()
    {
        dof.active = true;
        DOTween.To(() =>dof.gaussianMaxRadius.value, x => dof.gaussianMaxRadius.value = x, maxRadius, time).SetUpdate(true);
        DOTween.To(() => colorEffect.colorFilter.value, x => colorEffect.colorFilter.value = x, targetColor, time).SetUpdate(true);
    }
}
