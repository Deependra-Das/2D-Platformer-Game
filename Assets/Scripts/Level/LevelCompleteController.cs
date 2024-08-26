using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public GameObject LevelCompletedPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            AudioManager.Instance.PlaySFX(AudioTypeList.telportUsed);
            Debug.Log("Level Completed");
            LevelManager.Instance.SetCurrentLevelCompleted();
            LevelCompletedPanel.SetActive(true);
        }
    }
  
}
