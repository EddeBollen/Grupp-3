using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeonPlayerInteract : MonoBehaviour
{
    public GridSystem gridSystem;

    void OnInteract()
    {
        Debug.Log(gridSystem.hovering);
        if (gridSystem.hovering != null && gridSystem.hovering.gameObject.tag != "Player") 
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

    //private void Update()
    //{
    //    Item item = InventoryManager.instance.GetSelectedItem(false);
    //}
}
