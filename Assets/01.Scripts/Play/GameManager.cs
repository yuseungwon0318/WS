using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public bool isStarted = false;
    public int CountdownTime = 3;
    public float time;
    public float Score;
    public KickboardController player;
    public UnityEvent GameStartEvent;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        player = GameObject.FindObjectOfType<KickboardController>();
        isStarted = false;
        time = 0;
    }

    private void Start()
    {
        Play();
    }
    public void End()
    {
        
    }
    public void CheckScore()
    {

    }
    public void Play()
    {
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {
        Time.timeScale = 0;
        for(int i = 0; i < CountdownTime; i++)
        {
            yield return new WaitForSecondsRealtime(1f);
        }
        Time.timeScale = 1;
        isStarted = true;
        GameStartEvent?.Invoke();
    }

    void Update()
    {
        if(isStarted && !player.isDead)
        {
            time += Time.deltaTime;
        }
    }

    public void UDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
