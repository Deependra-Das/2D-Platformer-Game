using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetectionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Collision Detected");

        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player Fell Down");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
