using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[System.Serializable]
public class Own
{
    public int Coin;
    public bool[] owns;
}

public class BuySystem : MonoBehaviour
{
    public Own own;
    static public BuySystem Instance;
    public List<KickBoardSO> datas = new List<KickBoardSO>();

    [Header("Save")]
    public string path;
    public string folderName;
    public string fileName;


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        own.owns = new bool[datas.Count];
        own.owns[0] = true;

        path = Application.persistentDataPath + "/" + folderName;

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        Load();

    }
    
    public void UpCoin(int coin)
    {
        own.Coin += coin;
    }

    
    public void Buy(KickBoardSO data)
    {
        own.Coin -= data.Price;
        own.owns[datas.FindIndex(x => x == data)] = true;
        Save();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(own);
        string filePath = path + "/" + fileName;
        File.WriteAllText(filePath, json);
    }

    public void Load()
    {
        string filePath = path + "/" + fileName;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Own loaded = JsonUtility.FromJson<Own>(json);

             own = loaded;
        }
        else
        {
            for(int i = 0; i <own.owns.Length; i++) //�����
            {
                own.owns[i] = false;
            }

            own.owns[0] = true;
            own.Coin = 0;
            Save();
        }
    }
}