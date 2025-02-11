using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimalProduction : MonoBehaviour
{
    public TextMeshPro pigMushroom;

    bool isProducing = false;

    int pigMushroomProduced = 0;

    public int GetPigMushrooms()
    {
        return pigMushroomProduced;
    }

    void Start()
    {
        pigMushroom.text = pigMushroomProduced.ToString();
    }

    void Update()
    {
        if (isProducing == false)
        {
            Debug.Log("Producing");
            isProducing = true;
            StartCoroutine(Produce());
        }
    }

    private IEnumerator Produce()
    {
        yield return new WaitForSeconds(1f);

        pigMushroomProduced++;
        pigMushroom.text = pigMushroomProduced.ToString();

        isProducing = false;
    }
}
