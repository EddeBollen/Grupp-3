using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    int maxHealth = 100;
    public int currentHealth = 100;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage(50);
        }
    }
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            Debug.Log("Animal Dead");
        } else
        {
            currentHealth = -50;
        }
    }
}
