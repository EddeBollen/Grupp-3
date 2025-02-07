using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridSystem : MonoBehaviour
{
    public Vector3 gridPosition;
    public Vector2 mousePos;
    public float gridDistance;
    [SerializeField] public GameObject playerObject;
    public Collider2D hovering;

    public Vector3 CalcGrid(Vector3 instance)
    {
        gridPosition = new Vector3(Mathf.Round(instance.x), Mathf.Round(instance.y), -1f);
        Debug.Log(gridPosition);
        return gridPosition;
    }

    public float GridDistance(GameObject a, GameObject b)
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

        hovering = Physics2D.OverlapPoint(mousePos);
    }
}
