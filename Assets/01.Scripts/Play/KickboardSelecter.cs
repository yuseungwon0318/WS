using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;
public class latelyKickboard
{
    public int index;
}
public class KickboardSelecter : MonoBehaviour
{
    static public KickboardSelecter Instance;
    public KickBoardSO CurrentKickBoard;

    [Header("Save")]
    public string path;
    public string folderName = "SaveFolder";
    public string fileName = ".Json";

    private latelyKickboard kickboard;
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
        path = Application.persistentDataPath + "/" + folderName;

    }

    private void Start()
    {
        ClickSelect();
    }
    public void ClickSelect()
    {
        ShopDesc shop = GameObject.FindObjectOfType<ShopDesc>();
        CurrentKickBoard = shop.CurrentBoard;
        shop.CheckSelect();
    }
    public void Save()
    {
        PlayerPrefs.SetInt("Last", BuySystem.Instance.datas.FindIndex(x => x == CurrentKickBoard));
    }

    public void Load()
    {

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Play")
        {
            GameManager.instance.SetKickboard(CurrentKickBoard);
        }
    }
}
