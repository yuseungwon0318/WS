using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Shop : MonoBehaviour
{
    public RectTransform ShopPannel;
    private Vector3 origin = new Vector3(380,250, 0);

    private void Start()
    {
        
    }

    public void ShopClick()
    {
        ShopPannel.DOMove(origin, 1);    
    }

}
