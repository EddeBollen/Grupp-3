using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    GameObject gameController;
    GridSystem gridSystem;
    [SerializeField] int hits;
    bool canBreak = true;
    float timer = 0;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        gridSystem = gameController.GetComponent<GridSystem>();
    }
    private void Update()
    {
        Item item = InventoryManager.instance.GetSelectedItem(false);
        if (Input.GetMouseButtonDown(0))
        {
            if (gridSystem.hovering != null && gridSystem.hovering.gameObject == gameObject && item.type == ItemType.Tool && item.actionType == ActionType.Mine && gridSystem.GridDistance(gridSystem.playerObject, gridSystem.hovering.gameObject) <= 2.0f && canBreak == true)
            {
                hits--;
                canBreak = false;
                StartCoroutine(BreakingRoutine());
            }
        }

        if (hits <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BreakingRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        canBreak = true;
    }
}
