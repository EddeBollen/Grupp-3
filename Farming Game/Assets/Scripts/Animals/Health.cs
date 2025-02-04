using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MaxHealth = 100;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage(100);
        }
    }
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException();
        }
    }
}
