using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimalProduction : MonoBehaviour
{
    public TextMeshPro textLabel;

    bool isProducing = false;

    int produced = 0;

    void Start()
    {
        textLabel.text = produced.ToString();
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

        produced++;
        textLabel.text = produced.ToString();

        isProducing = false;
    }
}
