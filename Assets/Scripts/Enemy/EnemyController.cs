using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody2d;
    private Animator enemyAnimator;

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject groundDetector;
    [SerializeField] private float rayDistance;
    [SerializeField] private int directionChanger;


    private void Start()
    {
        enemyRigidbody2d = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        if(directionChanger==-1)
        {
            FlipSprite();
        }
    }


    void Update()
    {
        patrolEnemy();
    }

    private void patrolEnemy()
    {
        enemyAnimator.SetBool("IsPatrol", true);

        transform.Translate(directionChanger * Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(groundDetector.transform.position, Vector2.down, rayDistance);

        if (!hit)
        {
            FlipSprite();
            directionChanger *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerObject = other.gameObject.GetComponent<PlayerController>();
            playerObject.DecreaseHealth(1);
        }
    }

    private void FlipSprite()
    {
        Vector3 scaleVector = transform.localScale;
        scaleVector.x *= -1;
        transform.localScale = scaleVector;
    }

}
