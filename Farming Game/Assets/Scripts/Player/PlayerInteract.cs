using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    GameObject gameController;
    GridSystem gridSystem;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        gridSystem = gameController.GetComponent<GridSystem>();
    }

    void OnInteract()
    {
        if (gridSystem.hovering != null)
        {
            if (gridSystem.GridDistance(gridSystem.playerObject, gridSystem.hovering.gameObject) <= 2f)
            {
                Debug.Log("Interact success, interacted with " + gridSystem.hovering.gameObject.name + "!");
            }
            else
            {
                Debug.Log("Too far away to interact!");
            }
        }
    }

    private void Update()
    {
        Item item = InventoryManager.instance.GetSelectedItem(false);

        if (Input.GetMouseButtonDown(0))
        {
            if (item.type == ItemType.BuildingBlock && !Physics2D.OverlapPoint(gridSystem.CalcGrid(gridSystem.mousePos)))
            {
                Instantiate(item.gameObject, gridSystem.CalcGrid(gridSystem.mousePos), Quaternion.identity);
            }
        }
    }
}
