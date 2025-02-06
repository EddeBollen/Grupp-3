using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;

    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float sprintSpeed = 5f;
    [SerializeField] float maxStamina = 5f;
    [SerializeField] float staminaDrainRate = 1f;
    [SerializeField] float staminaRegenRate = 0.5f;

    bool isSprinting;
    float currentSpeed;
    float currentStamina;

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
        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        if (currentStamina < 1)
        {
            currentSpeed = moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
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

        rb.velocity = moveInput * currentSpeed;

      
    }
}