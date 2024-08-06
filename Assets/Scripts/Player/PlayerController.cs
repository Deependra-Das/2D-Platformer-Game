using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        Debug.Log("Player Controller Awake.");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision: "+ collision.gameObject.name);
    //}

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

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

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }

        float jump_vertical = Input.GetAxisRaw("Vertical");
        Vector3 position = transform.position;

        if (jump_vertical > 0f)
        {
            animator.SetBool("Jump", true);
        }
        if (jump_vertical <= 0f) 
        {
            jump_vertical = 0f;
            animator.SetBool("Jump", false);
        }
        transform.localPosition = position;



    }
}
