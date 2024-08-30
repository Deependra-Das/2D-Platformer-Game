using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class LevelSelectController : MonoBehaviour
{

    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private Button startLevelButton;

    public string selectedLevelName;

    [SerializeField]
    private Sprite DefaultButtonSprite;

    [SerializeField]
    private Sprite SelectedButtonSprite;

    [SerializeField]
    private Image levelStatusImage;

    [SerializeField]
    private Sprite[] statusImageSpriteList;

    public LevelButtonItem[] LevelButtonList;


    void Start()
    {
        closeButton.onClick.AddListener(onClickCloseButton);
        startLevelButton.onClick.AddListener(onClickStartLevelButton);
    }

    private void Update()
    {
        if (string.IsNullOrEmpty(selectedLevelName))
        {
            startLevelButton.interactable = false;
        }
        else
        {
            startLevelButton.interactable = true;
        }

        if (levelStatusImage.sprite == null)
        {
            levelStatusImage.enabled = false;
        }
        else
        {
            levelStatusImage.enabled = true;
        }
    }

    private void onClickStartLevelButton()
    {
       LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(selectedLevelName);
        switch(levelStatus)
        {
            case LevelStatus.LOCKED:
                Debug.Log("Complete the previous Level to Unlock & Play this level.");
                break;
                
            case LevelStatus.UNLOCKED:
                AudioManager.Instance.PlaySFX(AudioTypeList.buttonStartClick);
                SceneManager.LoadScene(selectedLevelName);
        
                break;

            case LevelStatus.COMPLETED:
                AudioManager.Instance.PlaySFX(AudioTypeList.buttonStartClick);
                SceneManager.LoadScene(selectedLevelName);
           
                break;
        }
                
    }

    private void onClickCloseButton()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonBackClick);
        this.gameObject.SetActive(false);
    }

    public void setLevelToPlay(string levelName)
    {
        selectedLevelName = levelName;
        setAllButtonToDefaultState();
        foreach (LevelButtonItem levelButton in LevelButtonList)
        {
            if (levelButton.levelName == selectedLevelName)
            {
                levelButton.levelButtonImage.sprite = SelectedButtonSprite;
            }
        }
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonOptionClick);
        setLevelStatusImage();
    }

    private void setAllButtonToDefaultState()
    {
        foreach (LevelButtonItem levelButton in LevelButtonList)
        {
            levelButton.levelButtonImage.sprite = DefaultButtonSprite;
        }
    }

    public void setLevelStatusImage()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(selectedLevelName);

        if (levelStatus == LevelStatus.LOCKED)
        {
            levelStatusImage.sprite = statusImageSpriteList[0];
        }
        else
        {
            levelStatusImage.sprite = statusImageSpriteList[1];
        }

    }

}

[Serializable]
public class LevelButtonItem
{
    public string levelName;
    public Button levelButton;
    public Image levelButtonImage;
   
}
