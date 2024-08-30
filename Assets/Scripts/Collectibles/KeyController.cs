using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    [SerializeField]
    private Animator keyCollectibleAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerControllerObject = other.gameObject.GetComponent<PlayerController>();

        if (playerControllerObject != null)
        {
            keyCollectibleAnimator.SetBool("KeyCollected", true);
            AudioManager.Instance.PlaySFX(AudioTypeList.keyPickUp);
            playerControllerObject.KeyPickedUp();

            Destroy(gameObject);
        }
    }
}
