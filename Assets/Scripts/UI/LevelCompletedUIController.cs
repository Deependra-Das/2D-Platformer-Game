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

    [SerializeField]
    private ParticleSystem ConfettiParticles;

    private void Awake()
    {
        PlayNextLevelButton.onClick.AddListener(PlayNextLevel);
        BackToMenuButton.onClick.AddListener(BackToMenu);
    }

    private void OnEnable()
    {
        PlayConfettiParticles();
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

    public void PlayConfettiParticles()
    {
        ConfettiParticles.Play();
    }
}
