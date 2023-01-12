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
    public int Score;
    public int BestScore = 0;
    public int CurrentCoin;
    public KickboardController player;
    public UnityEvent GameStartEvent;
    public UnityEvent GetCoinEvent;

    public int CoinScoreRatio = 3;
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

    public void GetCoin(int n)
    {
        CurrentCoin += n;
        GetCoinEvent?.Invoke();
    }

    

    private void Start()
    {
        BackendGameData.Instance.GameDataGet();
        BestScore = BackendGameData.userData.BestScore;

        

        Play();
        
        Application.targetFrameRate = 120;
    }
    public void End()
    {
        
    }
    public void CheckScore()
    {
       
        Score = (int)time + CurrentCoin*CoinScoreRatio;
        
        if (BestScore < Score)
        {
            PlayerPrefs.SetInt("BestScore", Score);
            Debug.Log("최고점수 갱신");
            BackendGameData.Instance.GameDataInsert();
            BackendRank.Instance.RankInsert(Score);
            
            BestScore = Score;

            BackendRank.Instance.RankInsert(GameManager.instance.Score);
        }
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
        CheckScore();

        BackendRank.Instance.RankGet(); // [추가] 랭킹 불러오기 함수
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
