using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static MapManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(MapManager)) as MapManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
       
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    public bool A;
    public bool B;
    public bool C;
    public bool D;
    public bool E;
    public bool F;
    public bool G;
    public bool H;

    public bool AC;
    public bool BD;
    public bool EG;
    public bool FH;

    private void Start()
    {
       
    }
}
