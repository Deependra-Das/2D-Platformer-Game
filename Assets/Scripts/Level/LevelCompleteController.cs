using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelCompletedPanel;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            AudioManager.Instance.PlaySFX(AudioTypeList.telportUsed);
            AudioManager.Instance.MuteAudioSource(AudioSourceList.audioSourcePlayer, true);
            AudioManager.Instance.MuteAudioSource(AudioSourceList.audioSourceEnemy, true);

            playerController.DisablePlayerSprite();
            playerController.enabled = false;

            LevelManager.Instance.SetCurrentLevelCompleted();
            LevelCompletedPanel.SetActive(true);
        }
        
    }
  
}
