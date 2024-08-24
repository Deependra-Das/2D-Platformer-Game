using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance {  get { return instance; } }

    public AudioSource audioSourceSFX;
    public AudioSource audioSourceBGM;

    public AudioType[] AudioList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioTypeList audio)
    {
        AudioClip clip = GetAudioClip(audio);
        if (clip != null)
        {
            audioSourceSFX.PlayOneShot(clip);
        }
        else 
        {
            Debug.LogError("Audio Clip not found for "+ audio);
        }
    }

    public void PlayBGM(AudioTypeList audio)
    {
        AudioClip clip = GetAudioClip(audio);
        if (clip != null)
        {
            audioSourceBGM.clip = clip;
            audioSourceBGM.Play();
        }
        else
        {
            Debug.LogError("Audio Clip not found for " + audio);
        }
    }

    public AudioClip GetAudioClip(AudioTypeList audio)
    {
        AudioType audioItem = Array.Find(AudioList, item => item.audioType == audio);
        if (audioItem != null)
        {
            return audioItem.audioClip;
        }
        return null;
    }
}

public enum AudioTypeList
{
    backgroundMusic,
    buttonMenuClick,
    buttonOptionClick,
    buttonBackClick,
    buttonStartClick,
    playerWalk,
    playerDeath
}

[Serializable]
public class AudioType
{
    public AudioTypeList audioType;
    public AudioClip audioClip;
}
