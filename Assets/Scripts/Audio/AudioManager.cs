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
    public AudioSource audioSourcePlayer;
    public AudioSource audioSourceEnemy;
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

    public void PlayFootstepsAudio()
    {
        AudioClip clip = GetAudioClip((AudioTypeList)UnityEngine.Random.Range(5,9));
        audioSourcePlayer.clip = clip;
        audioSourcePlayer.Play();
    }

    public void PlayJumpFootestepAudio()
    {
        AudioClip clip = GetAudioClip(AudioTypeList.playerFootstepJump);
        audioSourcePlayer.clip = clip;
        audioSourcePlayer.Play();
    }

    public void PlayLandFootestepAudio()
    {
        AudioClip clip = GetAudioClip(AudioTypeList.playerFootstepLand);
        audioSourcePlayer.clip = clip;
        audioSourcePlayer.Play();
    }

    public void PlayEnemyFootestepAudio()
    {
        AudioClip clip = GetAudioClip((AudioTypeList)UnityEngine.Random.Range(15, 17));
        audioSourceEnemy.clip = clip;
        audioSourceEnemy.Play();
    }

    public void PlayEnemyAttackAudio()
    {
        AudioClip clip = GetAudioClip((AudioTypeList)UnityEngine.Random.Range(17, 21));
        audioSourceEnemy.clip = clip;
        audioSourceEnemy.Play();
        Debug.Log(clip.name);
    }
}

public enum AudioTypeList
{   backgroundMusic,
    buttonMenuClick,
    buttonOptionClick,
    buttonBackClick,
    buttonStartClick,
    playerFootstep1,
    playerFootstep2,
    playerFootstep3,
    playerFootstep4,
    playerFootstep5,
    playerFootstep6,
    playerFootstep7,
    playerFootstep8,
    playerFootstepJump,
    playerFootstepLand,
    enemyFootstep1,
    enemyFootstep2,
    enemyAttack1,
    enemyAttack2,
    enemyAttack3,
    enemyAttack4,
    keyPickUp,
}

[Serializable]
public class AudioType
{
    public AudioTypeList audioType;
    public AudioClip audioClip;
}

