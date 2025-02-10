using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class AnimalPatrol : MonoBehaviour
{
    System.Random rnd = new System.Random();

    int randomTime;

    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private Transform currentTarget;
    public float speed;
    private float dir = 1;

    bool isWaiting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointA.transform;
        anim.SetBool("isRunning", true);
        currentTarget = PointA.transform;



    }

    void Update()
    {
        if (!isWaiting)
        {
            rb.velocity = new Vector2(speed * dir, 0);
        }

        // Check if the animal is close to the target point
        if (!isWaiting && Vector2.Distance(transform.position, currentTarget.position) < 0.3f)
        {
            StartCoroutine(ChangeDirection());
        }
    }

    IEnumerator ChangeDirection()
    {
        randomTime = rnd.Next(1, 4);

        isWaiting = true; // Prevent multiple coroutine calls
        rb.velocity = Vector2.zero; // Stop movement while waiting

        yield return new WaitForSeconds(randomTime); // Adjust wait time as needed

        // Swap direction and target point
        if (currentTarget == PointA.transform)
        {
            currentTarget = PointB.transform;
            dir = -1;
        }
        else
        {
            currentTarget = PointA.transform;
            dir = 1;
        }

        flip(); // Flip the sprite

        isWaiting = false; // Resume movement
    }

    void flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the sprite by inverting scale.x
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}
