using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Make sure to include this!

public class PlantFunctions : MonoBehaviour
{
    private bool isWatering = false;

    void Update()
    {
        if (isWatering)
        {
            Debug.Log("Water");
        }
    }

    void OnWater(InputValue value)
    {
        isWatering = value.isPressed;
    }
}
