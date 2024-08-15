using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D enemyRigidbody2d;
    private Animator enemyAnimator;
    private Transform currentPoint;
    public float speed;

    private void Start()
    {
        enemyRigidbody2d = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        currentPoint = pointB.transform;

    }

    public void Update()
    {
       // Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            enemyRigidbody2d.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemyRigidbody2d.velocity = new Vector2(-speed, 0);
        }
         
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            FlipSprite();
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            FlipSprite();
            currentPoint = pointB.transform;
        }


    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerObject = other.gameObject.GetComponent<PlayerController>();
            playerObject.DamagePlayer(1);
        }
    }

    private void FlipSprite()
    {
        Vector3 localScale = transform.localScale;
        localScale.x*=-1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

}
