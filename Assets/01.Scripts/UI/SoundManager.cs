using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer aMixer;

    public Slider sfx;
    public Slider bgm;
    public Slider master;

    private void Start()
    {
        sfx.maxValue = 0;   bgm.maxValue = 0;   master.maxValue = 0;
        sfx.minValue = -40; bgm.minValue = -40; master.minValue = -40;


    }


    public void Change()
    {
        aMixer.SetFloat("SFX", sfx.value);
        aMixer.SetFloat("BGM", bgm.value);
        aMixer.SetFloat("Master", master.value);
    }
}

