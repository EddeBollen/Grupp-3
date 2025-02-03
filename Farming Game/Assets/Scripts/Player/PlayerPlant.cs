using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; // Required for new Input System

public class PlayerPlant : MonoBehaviour
{
    [SerializeField] float cooldown = 2;
    bool isWatering = false;
    bool isTouchingPlant = false;

    void OnWater(InputValue value)
    {

        isWatering = value.isPressed;

        //if (canWater)
        //{
        //    StartCoroutine(WaterRoutine());
        //}
    }

    private IEnumerator WaterRoutine()
    {
        isWatering = true;
        Debug.Log("Watering");

        yield return new WaitForSeconds(cooldown); // Wait for 5 seconds

        isWatering = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            Debug.Log("Touched plant!");
            isTouchingPlant = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            Debug.Log("Plant left!");
            isTouchingPlant = false;
        }
    }

    private void Update()
    {
        // You can add additional logic here if needed
        if (isWatering)
        {
            //Debug.Log("Watering");
        }
    }
}
