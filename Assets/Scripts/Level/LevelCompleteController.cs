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
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            LevelManager.Instance.SetCurrentLevelCompleted();
            LevelCompletedPanel.SetActive(true);
            LevelCompletedPanel.gameObject.GetComponentInChildren<LevelCompletedUIController>().PlayConfettiParticles();
        }
        
    }
  
}
