using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public bool isStarted = false;
    public float CountdownTime;
    public float time;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        isStarted = false;
        time = 0;
    }

    private void Start()
    {
        
    }

    public void Play()
    {

    }
    IEnumerator Countdown()
    {
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
