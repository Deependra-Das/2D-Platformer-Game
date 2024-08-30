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

    [SerializeField]
    private ParticleSystem ExplosionParticles;

    private void Awake()
    {
        RestartLevelButton.onClick.AddListener(RestartLevel);
        BackToMenuButton.onClick.AddListener(BackToMenu);
    }

    private void OnEnable()
    {
        PlayExplosionParticles();
    }

    public void RestartLevel()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonStartClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonMenuClick);
        AudioManager.Instance.PlaySFX(AudioTypeList.buttonMenuClick);
        SceneManager.LoadScene(0);
    }

    public void PlayExplosionParticles()
    {
        ExplosionParticles.Play();
    }
}
