using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int scoreValue = 0;
    private PlayerController playerObject;

    public Image[] healthImageList;

    [SerializeField] 
    private GameObject GameOverUIPanel;

    void Start()
    {
        playerObject = GameObject.Find("Player").GetComponent<PlayerController>();
        GameOverUIPanel.SetActive(false);

        foreach (Image img in healthImageList)
        {
            img.GetComponentInChildren<CanvasRenderer>().gameObject.SetActive(true);
        }

        RefreshUI();
        AudioManager.Instance.MuteAudioSource(AudioSourceList.audioSourcePlayer, false);
        AudioManager.Instance.MuteAudioSource(AudioSourceList.audioSourceEnemy, false);
        AudioManager.Instance.MuteAudioSource(AudioSourceList.audioSourceSFX, false);
        AudioManager.Instance.MuteAudioSource(AudioSourceList.audioSourceBGM, false);
        AudioManager.Instance.PlayBGM(AudioTypeList.backgroundMusic);
    }

    private void Update()
    {
        RefreshHealthUI();
    }

    public void IncreaseScore(int scoreIncrementValue)
    {
       scoreValue += scoreIncrementValue;
       RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
       
    }

    private void RefreshHealthUI()
    {
        int currentPlayerLives = playerObject.getPlayerLives();

        foreach (Image img in healthImageList)
        {
            img.GetComponentInChildren<CanvasRenderer>().gameObject.SetActive(false);
        }

        for (int i = 0; i < currentPlayerLives; i++)
        {
            healthImageList[i].GetComponentInChildren<CanvasRenderer>().gameObject.SetActive(true);
        }
    }

    public void ActivateGameOverPanel()
    {
        GameOverUIPanel.SetActive(true);
        GameOverUIPanel.gameObject.GetComponentInChildren<GameOverUIController>().PlayExplosionParticles();
        AudioManager.Instance.PlayBGM(AudioTypeList.MusicDeathSting);
        AudioManager.Instance.MuteAudioSource(AudioSourceList.audioSourcePlayer, true);
        AudioManager.Instance.MuteAudioSource(AudioSourceList.audioSourceEnemy, true);

    }

}
