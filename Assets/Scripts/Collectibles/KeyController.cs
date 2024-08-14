using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    private Animator keyCollectibleAnimator;

    private void Start()
    {
        keyCollectibleAnimator = GetComponent<Animator>();
 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerControllerObject = other.gameObject.GetComponent<PlayerController>();
            keyCollectibleAnimator.SetBool("KeyCollected", true);
            playerControllerObject.KeyPickedUp();

            Destroy(gameObject);
        }
    }
}
