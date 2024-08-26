using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompletedUIController : MonoBehaviour
{
    [SerializeField]
    private Button PlayNextLevelButton;

    [SerializeField]
    private Button BackToMenuButton;

    private void Awake()
    {
        PlayNextLevelButton.onClick.AddListener(PlayNextLevel);
        BackToMenuButton.onClick.AddListener(BackToMenu);
    }
    public void PlayNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (LevelManager.Instance.IsValidLevel(nextSceneIndex))
        {
            AudioManager.Instance.PlaySFX(AudioTypeList.buttonStartClick);
            SceneManager.LoadScene(nextSceneIndex);

        }

    }

    public void BackToMenu()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonMenuClick);
        SceneManager.LoadScene(0);
    }
}
