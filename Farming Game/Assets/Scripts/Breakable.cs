using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GridSystem gridSystem;
    [SerializeField] int hits;
    bool canBreak = true;

    private void Update()
    {
        Item item = InventoryManager.instance.GetSelectedItem(false);
        Debug.Log(item);
        if (Input.GetMouseButtonDown(0))
        {
            if (gridSystem.hovering != null && gridSystem.hovering.gameObject == gameObject && item.actionType == ActionType.Mine && gridSystem.GridDistance(gridSystem.playerObject, gridSystem.hovering.gameObject) <= 2.0f && canBreak == true)
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
