using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerControllerObject = other.gameObject.GetComponent<PlayerController>();
            playerControllerObject.KeyPickedUp();
            Destroy(gameObject);
        }
    }
}
