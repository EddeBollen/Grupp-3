using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private GameObject Animal = default;
    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    void Start()
    {
        Animal = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                Animal.SetActive(attacking);
            }
        }
    }

    private void attack()
    {
        attacking = true;
        Animal.SetActive(attacking);
    }
}
