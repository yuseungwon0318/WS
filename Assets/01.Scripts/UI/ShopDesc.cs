using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;


public class ShopDesc : MonoBehaviour
{
    public List<KickBoardSO> boards = new List<KickBoardSO>(); //알아서 넣어
    public KickBoardSO CurrentBoard;
    public KickboardRender render;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI PriceText;
    public Button BuyButton;
    public TextMeshProUGUI BuyButtonText;

    void Start()
    {
        render = GameObject.FindObjectOfType<KickboardRender>();
        boards = boards.OrderBy(item => item.Price).ToList();
        BuySystem.Instance.datas = boards;
        CurrentBoard = boards[0];
        ChangeTarget();
    }

    void Update()
    {
        
    }

    public void LeftClick()
    {
        if (boards.IndexOf(CurrentBoard) != 0)
        {
            CurrentBoard = boards[boards.IndexOf(CurrentBoard) - 1];
        }
        else
        {
            return;
        }
        ChangeTarget();
    }
    public void RightClick()
    {
        if (boards.IndexOf(CurrentBoard) != boards.Count - 1)
        {
            CurrentBoard = boards[boards.IndexOf(CurrentBoard) + 1];
        }
        else
        {
            return;
        }
        ChangeTarget();
    }

    public void ChangeTarget()
    {
        render.Data = CurrentBoard;
        render.SetupVisual();
        NameText.text = CurrentBoard.Name;
        DescriptionText.text = CurrentBoard.Description;
        PriceText.text = CurrentBoard.Price + " Coin";
    }

    public void ClickBuyBtn()
    {
        if(CurrentBoard.Price <= BuySystem.Instance.Coin)
        {
            //BuySystem.Instance.DownCoin(CurrentBoard.Price);
        }
    }
}
