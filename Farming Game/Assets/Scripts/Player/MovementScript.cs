using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float sprintSpeed = 9f;
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
        isSprinting = value.isPressed;
    }

    private void Update()
    {
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
        rb.velocity = moveInput * currentSpeed;
        //Debug.Log(isSprinting);
    }

}