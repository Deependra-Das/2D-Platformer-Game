using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerController : MonoBehaviour
{
    [SerializeField ]private TextMeshProUGUI scoreText;
    private int scoreValue = 0;
    
    void Start()
    {
      RefreshUI();
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

}
