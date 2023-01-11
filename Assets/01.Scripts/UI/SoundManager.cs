using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public class Sound
{
    public float sfx;
    public float bgm;
    //public float master;

    public Sound(float sfx, float bgm)
    {
        this.sfx = sfx;
        this.bgm = bgm;
        //this.master = master;
    }
}
public class SoundManager : MonoBehaviour
{
    public AudioMixer aMixer;

    public Slider sfx;
    public Slider bgm;
    //public Slider master;
    public string path;
    public string folderName;
    public string fileName;
    private void Start()
    {
        path = Application.persistentDataPath + "/" + folderName;
        sfx.maxValue = 0;   bgm.maxValue = 0;   //master.maxValue = 0;
        sfx.minValue = -40; bgm.minValue = -40; //master.minValue = -40;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        Load();
    }
    public void Save()
    {
        Sound sound = new Sound(sfx.value, bgm.value);
        string json = JsonUtility.ToJson(sound);
        string filePath = path + "/" + fileName;
        File.WriteAllText(filePath ,json);
    }
    public void Load()
    {
        string filePath = path + "/" + fileName;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Sound sound = JsonUtility.FromJson<Sound>(json);
            sfx.value = sound.sfx;
            bgm.value = sound.bgm;
            //master.value = sound.master;
            Change();
        }
        else
        {
            sfx.value = 0;
            bgm.value = 0;
            Change();
        }
    }

    public void Change()
    {
        aMixer.SetFloat("SFX", sfx.value == -40 ? -80 : sfx.value);
        aMixer.SetFloat("BGM", bgm.value == -40 ? -80 : bgm.value);
        //aMixer.SetFloat("Master", master.value == -40 ? -80 : master.value); 생각해보니 마스터를 안씀

        Save();
    }
}

