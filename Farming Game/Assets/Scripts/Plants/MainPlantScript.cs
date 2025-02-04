using System.Collections;
using UnityEngine;

public class MainPlantScript : MonoBehaviour
{
    [SerializeField] private Sprite[] plantStages;

    private SpriteRenderer spriteRenderer; // Reference to the sprite
    private PlayerPlant playerPlant;

    public float currentWater = 0;
    private float waterMin = 5f;
    private float waterMax = 18f;
    private bool canIncreaseWater = true;
    private int currentStage = 0; // Track which stage we're in

    private bool _isTouchingPlant;
    private bool _isWatering;

    private void Start()
    {
        playerPlant = FindObjectOfType<PlayerPlant>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer

        if (playerPlant == null)
        {
            Debug.LogError("PlayerPlant script not found in the scene!");
        }
    }

    void Update()
    {
        if (playerPlant != null)
        {
            _isTouchingPlant = playerPlant.GetPlantTouch();
            _isWatering = playerPlant.GetWatering();
        }

        if (_isTouchingPlant && _isWatering && canIncreaseWater)
        {
            StartCoroutine(WaterPlantRoutine());
        }

        UpdatePlantStage(); // Check if plant should evolve
    }

    private IEnumerator WaterPlantRoutine()
    {
        canIncreaseWater = false; // Prevents immediate re-execution
        currentWater++;
        Debug.Log("Current water: " + currentWater);

        yield return new WaitForSeconds(1f); // Wait 1 second before allowing another increase

        canIncreaseWater = true; // Re-enable watering
    }

    private void UpdatePlantStage()
    {
        if (currentWater >= waterMin && currentStage == 0)
        {
            ChangePlantStage(1); // Second plant stage
        }
        else if (currentWater >= waterMax / 2 && currentStage == 1)
        {
            ChangePlantStage(2); // Third plant stage
        }
        else if (currentWater >= waterMax && currentStage == 2)
        {
            ChangePlantStage(3); // Final plant stage
        }
    }

    private void ChangePlantStage(int newStage)
    {
        if (newStage >= plantStages.Length) return; // Prevent out-of-bounds error

        spriteRenderer.sprite = plantStages[newStage]; // Change sprite
        currentStage = newStage; // Update stage tracker
        Debug.Log("Plant evolved to stage: " + newStage);
    }
}
