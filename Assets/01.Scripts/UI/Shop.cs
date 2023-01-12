using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Shop : MonoBehaviour
{
    public RectTransform Rect;

    private Vector3 origin = new Vector3(0, 0, 0);
    private Vector3 shoporigin = new Vector3(-3000, 0, 0);


    private void OnEnable()
    {
        GoOrigin(0);
        //Rect.transform.position = shoporigin;
    }

    public void ShopClick(float time)
    {
        Rect.DOLocalMove(origin, time);
    }
    public void GoOrigin(float time)
    {
        Rect.DOLocalMove(shoporigin, time);
    }

    
}
