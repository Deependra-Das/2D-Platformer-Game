using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Rigidbody2D playerRigidbody2d;
    [SerializeField] private BoxCollider2D boxCol;
    [SerializeField] private float playerHorizontalSpeed;
    [SerializeField] private float playerVerticalJumpHeight;

    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    private bool isGrounded;

    private void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;

    }

    public void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Jump");

        PlayerMovement(horizontalInput, VerticalInput);
        PlayerMovementAnimation(horizontalInput, VerticalInput);
    }

    public void PlayerMovement(float horizontalInput, float verticalInput)
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += horizontalInput * playerHorizontalSpeed * Time.deltaTime;
        transform.position = currentPosition;

        if (verticalInput > 0 && isGrounded)
        {
            PlayJumpAnimation();
            playerRigidbody2d.AddForce(new Vector2(0f, playerVerticalJumpHeight), ForceMode2D.Impulse);
        }

    }

    public void PlayerMovementAnimation(float horizontalInput, float verticalInput)
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 scale = transform.localScale;
        if (horizontalInput < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayCrouchAnimation(true);
        }
        else
        {
            PlayCrouchAnimation(false);
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

            boxCol.size = new Vector2(sizeX, sizeY);
            boxCol.offset = new Vector2(offX, offY);
        }

        else
        {
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
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

}
