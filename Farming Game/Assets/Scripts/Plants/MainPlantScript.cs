using System.Collections;
using UnityEngine;

public class MainPlantScript : MonoBehaviour
{
    [SerializeField] private Sprite[] plantStages;
    [SerializeField] Sprite defaultPlant;

    private SpriteRenderer spriteRenderer;
    private PlayerPlant playerPlantScript;

    public float currentWater = 0;
    private int currentStage = -1;

    private bool _isTouchingPlant;
    private bool _isWatering = false;
    private bool _plantWatered = false;
    private bool _playerHarvest = false;

    public bool _plantGrowing = false;
    public bool _plantGrown = false;

    private void Start()
    {
        playerPlantScript = FindObjectOfType<PlayerPlant>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (playerPlantScript == null)
        {
            Debug.LogError("PlayerPlant script not found in the scene!");
        }
    }

    void Update()
    {
        if (playerPlantScript != null)
        {
            _isTouchingPlant = playerPlantScript.GetPlantTouch();
            _isWatering = playerPlantScript.GetWatering();
            _playerHarvest = playerPlantScript.GetHarvest();
        }

        if (_isTouchingPlant && _isWatering && !_plantWatered)
        {
            StartCoroutine(WaterPlantRoutine());
            spriteRenderer.color = Color.blue;
            _plantWatered = true; // Start growing automatically after watering
            _plantGrowing = true;
        }

        if (_playerHarvest && _isTouchingPlant && _plantGrown)
        {
            _plantWatered = false;
            _plantGrown = false;

            currentStage = -1;

            spriteRenderer.sprite = defaultPlant;
            spriteRenderer.color = Color.grey;

            Debug.Log("Player harvested plant");
        }

        if (_plantGrowing && currentStage == plantStages.Length - 1)
        {
            _plantGrown = true;
            _plantGrowing = false;

            Debug.Log("Plant has fully grown! Current stage: " + currentStage);
            CancelInvoke(nameof(GrowPlantRoutine)); // Stop growing
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
            //_plantGrown = true;
            //Debug.Log("Plant has fully grown! Current stage: " + currentStage);
            //CancelInvoke(nameof(GrowPlantRoutine)); // Stop growing
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
