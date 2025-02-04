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
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float sprintSpeed = 7f;
    bool isSprinting;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnRunning(InputValue value)
    {
        if (value.isPressed == true)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private void Update()
    {
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
        rb.velocity = moveInput * currentSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }
}