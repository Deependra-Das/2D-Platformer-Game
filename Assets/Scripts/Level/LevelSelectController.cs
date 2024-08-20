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
        Debug.Log(selectedLevelName);
        SceneManager.LoadScene(selectedLevelName);
    }

    private void onClickCloseButton()
    {
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

    }

    private void setAllButtonToDefaultState()
    {
        foreach (GameObject levelButton in LevelButtonList)
        {
            levelButton.GetComponent<Image>().sprite = DefaultButtonSprite;
        }
    }
}
