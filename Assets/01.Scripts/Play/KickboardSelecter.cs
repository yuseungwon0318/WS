using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    }

    public void Save()
    {
        if (BuySystem.Instance.own.owns[kickboard.index])
        {
            string json = JsonUtility.ToJson(kickboard);
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {

    }
}
