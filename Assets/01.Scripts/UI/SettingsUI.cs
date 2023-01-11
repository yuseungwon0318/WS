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
        GoOrigin();
        //Rect.transform.position = shoporigin;
    }

    public void SettingsClick()
    {
        Rect.DOLocalMove(origin, 1);
    }
    public void GoOrigin()
    {
        Rect.DOLocalMove(settingOrigin, 1);
    }
}
