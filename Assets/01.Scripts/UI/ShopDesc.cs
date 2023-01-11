using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDesc : MonoBehaviour
{
    public List<KickBoardSO> boards = new List<KickBoardSO>(); //알아서 넣어
    public KickBoardSO CurrentBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
