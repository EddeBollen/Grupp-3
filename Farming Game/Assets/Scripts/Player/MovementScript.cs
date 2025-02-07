using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;

    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float sprintSpeed = 5f;
    [SerializeField] float staminaRegenRate = 1f;
    [SerializeField] float staminaDrainRate = 1f;
    [SerializeField] float maxStamina = 7;
    bool isSprinting;
    float currentSpeed;
    public float currentStamina;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Update()
    {
        if (currentStamina < 1)
        {
            currentSpeed = moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 1)
        {
            isSprinting = true;
            currentStamina -= staminaDrainRate * Time.deltaTime;
        }
        else
        {
            isSprinting = false;
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);


        if (isSprinting)
        {
            currentSpeed = moveSpeed;
        } 
        else if (currentStamina < maxStamina * 0.2f)
        {
            Debug.Log("Stamina is running low");
        }
        else if (currentStamina == maxStamina)
        {
            Debug.Log("Stamina is full");
        }
        else
        {
            Debug.Log("stamina is left");
            currentSpeed = moveSpeed;
        }

        rb.velocity = moveInput * currentSpeed;
    }
}