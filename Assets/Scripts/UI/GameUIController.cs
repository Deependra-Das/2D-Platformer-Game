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

    [SerializeField]
    private Button RestartLevelButton;

    [SerializeField]
    private Button BackToMenuButton;

    void Start()
    {
        playerObject = GameObject.Find("Player").GetComponent<PlayerController>();
        GameOverUIPanel.SetActive(false);

        foreach (Image img in healthImageList)
        {
            img.GetComponentInChildren<CanvasRenderer>().gameObject.SetActive(true);
        }

        RestartLevelButton.onClick.AddListener(RestartLevel);
        BackToMenuButton.onClick.AddListener(BackToMenu);

        RefreshUI();
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

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (LevelManager.Instance.IsValidLevel(nextSceneIndex))
        {
                SceneManager.LoadScene(nextSceneIndex);
                       
        }
      
    }

}
