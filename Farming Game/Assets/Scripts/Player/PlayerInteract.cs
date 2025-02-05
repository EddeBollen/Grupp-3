using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    Vector2 gridPosition;
    Vector2 mousePos;
    float gridDistance;
    [SerializeField] GameObject playerObject;
    Collider2D hit;
    public AudioSource audioSource;

    void OnInteract()
    {
        if (hit != null)
        {
            if (GridDistance(playerObject, hit.gameObject) <= 2f)
            {
                Debug.Log("Interact success, interacted with " + hit.gameObject.name + "!");
                audioSource.Play();
            }
            else
            {
                Debug.Log("Too far away to interact!");
            }
        }
    }

    void OnFire()
    {
        CalcGrid(mousePos);

        if (hit != null)
        {
            Destroy(hit.gameObject);
        }
    }

    Vector2 CalcGrid(Vector3 instance)
    {
        gridPosition = new Vector2(Mathf.Round(instance.x), Mathf.Round(instance.y));
        Debug.Log(gridPosition);
        return gridPosition;
    }

    float GridDistance(GameObject a, GameObject b)
    {
        Vector2 posA = CalcGrid(a.transform.position);
        Vector2 posB = CalcGrid(b.transform.position);
        Vector2 distance = new Vector2(Mathf.Max(posA.x, posB.x) - Mathf.Min(posA.x, posB.x), Mathf.Max(posA.y, posB.y) - Mathf.Min(posA.y, posB.y));
        gridDistance = Mathf.Max(distance.x, distance.y);
        Debug.Log(gridDistance);
        return gridDistance;
    }
        
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        hit = Physics2D.OverlapPoint(mousePos);
    }
}
