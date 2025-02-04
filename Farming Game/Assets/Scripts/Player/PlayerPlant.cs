using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; // Required for new Input System

public class PlayerPlant : MonoBehaviour
{
    [SerializeField] float cooldown = 2;
    

    GameObject _plantObject;
    
    bool _isWatering = false;
    bool _isTouchingPlant = false;

    public bool GetWatering()
    {
        return _isWatering;
    }

    public bool GetPlantTouch()
    {
        return _isTouchingPlant;
    }

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
            _isTouchingPlant = true;
            _plantObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            _isTouchingPlant = false;
            _plantObject = null;
        }
    }

    void GrowPlant(GameObject plant)
    {
        Vector2 newSize = new Vector2(plant.transform.localScale.x, plant.transform.localScale.y * 1.001f);
        plant.transform.localScale = newSize;
    }

    private void Update()
    {
        //You can add additional logic here if needed
        if (_isWatering)
        {
            //Debug.Log("Watering");

            if (_plantObject)
            {
                //GrowPlant(_plantObject); //UNCOMMENT FOR EXECUTION OF GROWPLANT
            }
        }   
            
    }
}
