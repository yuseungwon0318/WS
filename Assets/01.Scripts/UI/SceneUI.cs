using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Play");
    }

    public void Main()
    {
        SceneManager.LoadScene("Main");
    }

    public void End()
    {
        SceneManager.LoadScene("End");
    }
}
