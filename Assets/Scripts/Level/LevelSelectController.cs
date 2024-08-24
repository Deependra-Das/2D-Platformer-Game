using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelSelectController : MonoBehaviour
{

    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private Button startLevelButton;

    public string selectedLevelName;

    private GameObject[] LevelButtonList;

    [SerializeField]
    private Sprite DefaultButtonSprite;

    [SerializeField]
    private Sprite SelectedButtonSprite;

    void Start()
    {
        closeButton.onClick.AddListener(onClickCloseButton);
        startLevelButton.onClick.AddListener(onClickStartLevelButton);

        LevelButtonList = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(sr => sr.transform.name == "LevelButton").ToArray();
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
                AudioManager.Instance.PlayBGM(AudioTypeList.backgroundMusic);
                SceneManager.LoadScene(selectedLevelName);
        
                break;

            case LevelStatus.COMPLETED:
                AudioManager.Instance.PlaySFX(AudioTypeList.buttonStartClick);
                AudioManager.Instance.PlayBGM(AudioTypeList.backgroundMusic);
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
        foreach (GameObject levelButton in LevelButtonList)
        {
            if (levelButton.GetComponent<LevelLoader>().getLevelName() == selectedLevelName)
            {
                levelButton.GetComponent<Image>().sprite = SelectedButtonSprite;
            }
        }
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonOptionClick);

    }

    private void setAllButtonToDefaultState()
    {
        foreach (GameObject levelButton in LevelButtonList)
        {
            levelButton.GetComponent<Image>().sprite = DefaultButtonSprite;
        }
    }
}
