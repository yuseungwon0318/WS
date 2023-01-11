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

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;
    public Button BuyButton;
    public TextMeshProUGUI BuyButtonText;

    void Start()
    {
        boards = boards.OrderBy(item => item.Price).ToList();
        CurrentBoard = boards[0];
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
    }
}
