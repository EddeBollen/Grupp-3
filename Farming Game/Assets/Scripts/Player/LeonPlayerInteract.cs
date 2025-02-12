using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeonPlayerInteract : MonoBehaviour
{
    public GridSystem gridSystem;
    private AnimalProduction animalProductionScript;

    //Script variables
    int pigMushroomsProduced;

    //Resources
    int pigMushrooms;

    //Resources UI
    [SerializeField] GameObject pigMushroomsTextObject;

    TextMeshPro pigMushroomsText;

    private void Start()
    {
        pigMushroomsText = pigMushroomsTextObject.GetComponent<TextMeshPro>();
        pigMushroomsText.text = "test";
    }

    void OnInteract()
    {
        Debug.Log(gridSystem.hovering);
        if (gridSystem.hovering != null && gridSystem.hovering.gameObject.tag != "Player") 
        {
            if (gridSystem.GridDistance(gridSystem.playerObject, gridSystem.hovering.gameObject) <= 2f)
            {
                Debug.Log("Interact success, interacted with " + gridSystem.hovering.gameObject.name + "!");

                if (gridSystem.hovering.gameObject.tag == "Pig Mushrooms")
                {
                    Debug.Log("Interacted with Pig Mushrooms");
                    pigMushrooms = animalProductionScript.GetPigMushrooms();
                    pigMushroomsText.text += pigMushrooms.ToString();    
                }
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
