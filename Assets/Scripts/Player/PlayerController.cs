using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody2d;
    private BoxCollider2D playerBoxCollider2d;

    [SerializeField] 
    private float playerHorizontalSpeed;

    [SerializeField] 
    private float playerVerticalJumpHeight;

    [SerializeField] 
    private int playerLives;

    private bool isFacingRight=true;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    private bool isGrounded;
    private bool isDead = false;
    private Camera mainCamera;
    GameUIController gameUIControllerObject;

    private void Start()
    {
        playerRigidbody2d=GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBoxCollider2d = GetComponent<BoxCollider2D>();
        mainCamera = Camera.main;

        boxColInitSize = playerBoxCollider2d.size;
        boxColInitOffset = playerBoxCollider2d.offset;
        gameUIControllerObject = GameObject.Find("Canvas").GetComponent<GameUIController>();
    }

    public void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        PlayerMovement(horizontalInput);
        PlayerMovementAnimation(horizontalInput);
    }

    public void PlayerMovement(float horizontalInput)
    {
   
        playerRigidbody2d.velocity= new Vector2(horizontalInput * playerHorizontalSpeed, playerRigidbody2d.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidbody2d.velocity = new Vector2(playerRigidbody2d.velocity.x, playerVerticalJumpHeight);
        }
        if (Input.GetButtonUp("Jump") && playerRigidbody2d.velocity.y > 0f)
        {
            playerRigidbody2d.velocity = new Vector2(playerRigidbody2d.velocity.x, playerRigidbody2d.velocity.y * -0.5f);
        }

    }

    public void PlayerMovementAnimation(float horizontalInput)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = -1f * localScale.x;
            transform.localScale = localScale;
        }
      
        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayCrouchAnimation(true);
        }
        else
        {
            PlayCrouchAnimation(false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlayJumpAnimation();
        }
    }


    public void PlayCrouchAnimation(bool crouchValue)
    {
        if (crouchValue == true)
        {
            float offX = -0.158f;
            float offY = 0.615f;

            float sizeX = 0.767f;
            float sizeY = 1.275f;

            playerBoxCollider2d.size = new Vector2(sizeX, sizeY);
            playerBoxCollider2d.offset = new Vector2(offX, offY);
        }

        else
        {
            playerBoxCollider2d.size = boxColInitSize;
            playerBoxCollider2d.offset = boxColInitOffset;
        }

        playerAnimator.SetBool("Crouch", crouchValue);
    }

    public void PlayJumpAnimation()
    {
        playerAnimator.SetTrigger("Jump");
    }


    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    public void KeyPickedUp()
    {
        Debug.Log("Key Picked Up");
        gameUIControllerObject.IncreaseScore(10);
    }

    public void DecreaseHealth(int damageValue)
    {
        playerLives -= damageValue;
        CheckPlayerDeath();
    }

    public void CheckPlayerDeath()
    {
        if (playerLives < 1)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        isDead = true;
        mainCamera.transform.parent = null;
        this.enabled = false;
        gameUIControllerObject.ActivateGameOverPanel();
        playerRigidbody2d.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public int getPlayerLives()
    {
        return playerLives;
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
