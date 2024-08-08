using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private Animator playerAnimator;

    [SerializeField] 
    private BoxCollider2D boxCol;


    [SerializeField]
    private float playerHorizontalSpeed;

    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;


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

        if (verticalInput > 0)
        {
            PlayJumpAnimation();
        }


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
            float offX = -0.1581616f;
            float offY = 0.6157525f;

            float sizeX = 0.7675232f;
            float sizeY = 1.275061f;

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
}
