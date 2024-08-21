using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Completed");
            LevelManager.Instance.SetCurrentLevelCompleted();
            //SceneManager.LoadScene("Level0");
        }
    }
  
}
