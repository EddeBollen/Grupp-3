using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    Vector2 moveInput;
    public Rigidbody2D rb;

    [SerializeField] public float moveSpeed = 3f;
    [SerializeField] public float sprintSpeed = 5f;
    [SerializeField] float staminaRegenRate = 0.5f;
    [SerializeField] float staminaDrainRate = 1f;
    [SerializeField] float maxStamina = 7;
    [SerializeField] public float currentSpeed;
    public float currentStamina;
    public bool isSprinting;
    Animator ani;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        currentStamina = maxStamina;
        Debug.Log("Press Shift to start");
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Update()
    {
        //if (moveInput.x != 0)
        //{
        //    ani.SetBool("isRunning", true);
        //}
        //else
        //{
        //    ani.SetBool("isRunning", false);
        //}
            
        if (currentStamina < 1)
        {
            isSprinting = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0 && isSprinting)
        {
            isSprinting = true;
            currentStamina -= staminaDrainRate * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 2)
        {
            isSprinting = true;
            currentStamina -= staminaDrainRate * Time.deltaTime;
        }
        else
        {
            isSprinting = false;
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        if ((isSprinting) && currentStamina > 1)
        {
            currentSpeed = sprintSpeed;
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