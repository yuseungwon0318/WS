using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bought
{
    public string[] owned;
}

[System.Serializable]
public class own
{
    public KickBoardSO data;
    public bool isOwn;
}

public class BuySystem : MonoBehaviour
{
    static public BuySystem Instance;
    public Bought bought;
    public List<KickBoardSO> datas = new List<KickBoardSO>();
    private List<own> owned = new List<own>();
    [SerializeField]
    private int coin;
    public int Coin
    {
        get => coin;
        set
        {
            coin = Mathf.Clamp(coin+value,0,int.MaxValue);
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void UpCoin(int coin)
    {
        Coin += coin;
    }

    

    public void Buy(KickBoardSO data)
    {
        Coin -= data.Price;

    }

    public void Save()
    {
        bought.owned = new string[datas.Count];
        
    }
}
