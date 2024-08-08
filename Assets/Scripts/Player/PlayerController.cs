using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;

    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    private void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }

    public void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        playerAnimator.SetFloat("Speed", Mathf.Abs(speed));


        Vector3 scale = transform.localScale;
        if (speed < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


        float VerticalInput = Input.GetAxis("Vertical");

        PlayJumpAnimation(VerticalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
    }

    public void Crouch(bool crouch)
    {
        if (crouch == true)
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

        playerAnimator.SetBool("Crouch", crouch);
    }

    public void PlayJumpAnimation(float vertical)
    {
        if (vertical > 0)
        {
            playerAnimator.SetTrigger("Jump");
        }
    }
}
