using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; // Required for new Input System

public class PlayerPlant : MonoBehaviour
{
    [SerializeField] float cooldown = 2;

    GameObject _plantObject;
    
    bool _isWatering = false;
    bool _isTouchingPlant = false;
    bool _plantHarvested = false;
    bool _playerPlanted = false;
    bool _playerTilling = false;

    Item item;

    private void Start()
    {
        
    }

    public bool GetWatering()
    {
        return _isWatering;
    }

    public bool GetPlantTouch()
    {
        return _isTouchingPlant;
    }

    public bool GetHarvest()
    {
        return _plantHarvested;
    }

    public bool GetPlantAction()
    {
        return _playerPlanted;
    }

    public bool GetTill()
    {
        return _playerTilling;
    }

    void OnHarvest(InputValue value)
    {
        _plantHarvested = value.isPressed;
    }

    void OnPlant(InputValue value)
    {
        if (value.isPressed)
        {
            StartCoroutine(PlantRoutine());
        }
    }

    private IEnumerator PlantRoutine()
    {
        _playerPlanted = true;
        Debug.Log("Planted!");

        yield return new WaitForSeconds(0.5f);

        _playerPlanted = false;
        Debug.Log("Plant action reset!");
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
        item = InventoryManager.instance.GetSelectedItem(false);

        if (item)
        {
            if (item.actionType == ActionType.Water) // If you hold something that can water
            {
                if (Input.GetMouseButton(0))
                {
                    _isWatering = true;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    _isWatering = false;
                }
            }
            else
            {
                _isWatering = false;
            }

            if (item.actionType == ActionType.Till)
            {
                if (Input.GetMouseButton(0))
                {
                    _playerTilling = true;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    _playerTilling = false;
                }
            }
            else
            {
                _playerTilling = false;
            }
        }
    }
}
