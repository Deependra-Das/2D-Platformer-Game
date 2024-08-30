using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D enemyRigidbody2d;

    [SerializeField] 
    private Animator enemyAnimator;

    [SerializeField] 
    private float moveSpeed;

    [SerializeField] 
    private GameObject groundDetector;

    [SerializeField] 
    private GameObject playerDetector;

    [SerializeField] 
    private float rayDistance;

    [SerializeField] 
    private int directionChanger;


    private void Start()
    {
        if(directionChanger==-1)
        {
            FlipSprite();
        }
    }


    void Update()
    {
        patrolEnemy();
        AttackPlayer();
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
    private void AttackPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerDetector.transform.position, Vector2.right, rayDistance);

        if(hit)
        {
               enemyAnimator.SetTrigger("Attack");
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController playerObject = other.gameObject.GetComponent<PlayerController>();

        if (playerObject != null)
        {
            playerObject.DecreaseHealth(1);
        }
    }

    private void FlipSprite()
    {
        Vector3 scaleVector = transform.localScale;
        scaleVector.x *= -1;
        transform.localScale = scaleVector;
    }

    public void PlayEnemyFootestepAudio()
    {
        AudioManager.Instance.PlayEnemyFootestepAudio();
    }

    public void PlayEnemyAttackAudio()
    {
        AudioManager.Instance.PlayEnemyAttackAudio();
    }

}
