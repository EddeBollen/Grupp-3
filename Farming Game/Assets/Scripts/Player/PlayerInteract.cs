using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public GridSystem gridSystem;

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
            if (item.type == ItemType.BuildingBlock)
            {
                Instantiate(item.gameObject, gridSystem.CalcGrid(gridSystem.mousePos), Quaternion.identity);
            }
        }
    }
}
