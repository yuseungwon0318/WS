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

    public List<KickBoardSO> boards = new List<KickBoardSO>(); //알아서 넣어
    public KickBoardSO CurrentBoard;

    private void Start()
    {
        Rect.transform.position = shoporigin;
        CurrentBoard = boards[0];
    }

    public void ShopClick()
    {
        Rect.DOLocalMove(origin, 1);
    }
    public void GoOrigin()
    {
        Rect.DOLocalMove(shoporigin, 1);
    }

    
}
