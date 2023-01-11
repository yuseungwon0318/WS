using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public AudioSource m_AudioSource; 
    private void Update()
    {
        m_AudioSource.Play();
    }
}
