using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; // Required for new Input System

public class PlayerPlant : MonoBehaviour
{
    [SerializeField] float cooldown = 2;
    bool _isWatering = false;
    bool _isTouchingPlant = false;

    void OnWater(InputValue value)
    {
        _isWatering = value.isPressed;

        //if (canWater)
        //{
        //    StartCoroutine(WaterRoutine());
        //}
    }

    private IEnumerator WaterRoutine()
    {
        _isWatering = true;
        Debug.Log("Watering");

        yield return new WaitForSeconds(cooldown); // Wait for 5 seconds

        _isWatering = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            Debug.Log("Touched plant!");
            _isTouchingPlant = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            Debug.Log("Plant left!");
            _isTouchingPlant = false;
        }
    }

    private void Update()
    {
        // You can add additional logic here if needed
        if (_isWatering)
        {
            //Debug.Log("Watering");
            if (_isTouchingPlant)
            {

            }
        }
    }
}
