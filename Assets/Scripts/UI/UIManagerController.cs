using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManagerController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int scoreValue = 0;
    private PlayerController playerObject;

    public Image[] healthImageList;

    [SerializeField] 
    private GameObject deathUIPanel;

    void Start()
    {
      playerObject = GameObject.Find("Player").GetComponent<PlayerController>();

        foreach (Image img in healthImageList)
        {
            img.GetComponentInChildren<CanvasRenderer>().gameObject.SetActive(true);
        }

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

}
