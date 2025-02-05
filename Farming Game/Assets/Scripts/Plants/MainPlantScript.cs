using System.Collections;
using UnityEngine;

public class MainPlantScript : MonoBehaviour
{
    [SerializeField] private Sprite[] plantStages;

    private SpriteRenderer spriteRenderer;
    private PlayerPlant playerPlant;

    public float currentWater = 0;
    private float waterMin = 5f;
    private float waterMax = 18f;
    private int currentStage = -1;

    private bool _isTouchingPlant;
    private bool _isWatering = false;
    private bool _plantWatered = false;

    private void Start()
    {
        playerPlant = FindObjectOfType<PlayerPlant>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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

        if (_isTouchingPlant && _isWatering && !_plantWatered)
        {
            StartCoroutine(WaterPlantRoutine());
            spriteRenderer.color = Color.blue;
            _plantWatered = true; // Start growing automatically after watering
        }
    }

    private IEnumerator WaterPlantRoutine()
    {
        currentWater++;
        yield return new WaitForSeconds(1f); // Simulate watering time
        StartGrowth(); // Begin the slow growth process
    }

    private void StartGrowth()
    {
        Debug.Log("Plant will now start growing...");
        InvokeRepeating(nameof(GrowPlantRoutine), 2f, 3f); // Grow every 3 seconds
    }

    private void GrowPlantRoutine()
    {
        if (currentStage < plantStages.Length - 1) // Prevent out-of-bounds error
        {
            ChangePlantStage(currentStage + 1);
        }
        else
        {
            Debug.Log("Plant has fully grown! Current stage: " + currentStage);
            CancelInvoke(nameof(GrowPlantRoutine)); // Stop growing
        }
    }

    private void ChangePlantStage(int newStage)
    {
        if (newStage >= plantStages.Length) return;

        spriteRenderer.sprite = plantStages[newStage];
        currentStage = newStage;
        Debug.Log("Plant evolved to stage: " + newStage);
    }
}
