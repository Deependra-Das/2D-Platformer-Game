using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using Scene = UnityEngine.SceneManagement.Scene;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public string[] LevelsList;

   public static LevelManager Instance 
    { 
        get 
        { return instance; 
        } 
    }

    void Awake()
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

    void Start()
    {
        if (GetLevelStatus(LevelsList[0]) == LevelStatus.LOCKED)
        {
            SetLevelStatus(LevelsList[0], LevelStatus.UNLOCKED);
        }

    }

    public void SetCurrentLevelCompleted()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name,LevelStatus.COMPLETED);

        UnlockNextLevel(currentScene);
    }

    private void UnlockNextLevel(Scene currentScene)
    {
        int currentSceneIndex = Array.FindIndex(LevelsList, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;

        if (IsValidLevel(nextSceneIndex))
        {
            SetLevelStatus(LevelsList[nextSceneIndex], LevelStatus.UNLOCKED);
        }
    }


    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level,0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log(level + " : " + levelStatus);
    }

    public bool IsValidLevel(int levelIndex)
    {
        if (levelIndex < LevelsList.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetLevelSceneName(int levelIndex)
    {
        if(IsValidLevel(levelIndex))
        {
            return LevelsList[levelIndex];
        }
        else
        {
            return null;
        }
    }

}
