using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField]
    private Button RestartLevelButton;

    [SerializeField]
    private Button BackToMenuButton;

    private void Awake()
    {
        RestartLevelButton.onClick.AddListener(RestartLevel);
        BackToMenuButton.onClick.AddListener(BackToMenu);
    }

    public void RestartLevel()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonMenuClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonMenuClick);
        SceneManager.LoadScene(0);
    }
}
