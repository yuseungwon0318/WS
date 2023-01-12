using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SettingsUI : MonoBehaviour
{
    public RectTransform Rect;

    private Vector3 origin = new Vector3(0, 0, 0);
    private Vector3 settingOrigin = new Vector3(0, 1500, 0);


    private void OnEnable()
    {
        GoOrigin(0);
        //Rect.transform.position = shoporigin;
    }


    public void SettingsClick(float time)
    {
        Rect.DOLocalMove(origin, time);
    }
    public void GoOrigin(float time)
    {
        Rect.DOLocalMove(settingOrigin, time);
    }
}
