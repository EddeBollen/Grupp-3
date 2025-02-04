using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private Transform currentTarget;
    public float speed;
    private float dir = 1;
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
        rb.velocity = new Vector2(speed, 0) * dir;

        //Vector2 point = currentPoint.position - transform.position;
        if (currentTarget == PointA.transform && Vector2.Distance(transform.position, PointA.transform.position) < 0.3f)
        {
            dir = -1;
            currentTarget = PointB.transform;
        }
        else if (currentTarget == PointB.transform && Vector2.Distance(transform.position, PointB.transform.position) < 0.3f)
        {
            dir = 1;
            currentTarget = PointA.transform;
        }

        //Vector2 point = currentPoint.position - transform.position;
        //if(Vector2.Distance(transform.position, PointB.transform.position) < 0.1f)
        //{
        //    rb.velocity = new Vector2(speed, 0);
        //}
        //else
        //{
        //    rb.velocity = new Vector2(-speed, 0);
        //}

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            flip();
            currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}
