using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button QuitButton;

    private GameObject LevelSelectionPanel;

    void Start()
    {
        AudioManager.Instance.PlayBGM(AudioTypeList.backgroundMusic);
        playButton.onClick.AddListener(StartGameplay);
        QuitButton.onClick.AddListener(QuitGame);
        LevelSelectionPanel = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None).Where(sr => !sr.gameObject.activeInHierarchy && sr.transform.name=="LevelSelectorPanel").ToArray().DefaultIfEmpty().ElementAt(0);
    }

    public void StartGameplay()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonMenuClick);

        LevelSelectionPanel.SetActive(true);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonMenuClick);
        Application.Quit();
    }
}
