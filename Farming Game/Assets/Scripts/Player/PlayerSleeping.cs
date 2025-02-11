using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class SleepSystem : MonoBehaviour
{
    public float sleepDuration = 5f;
    public Transform bedPosition;
    private bool isSleeping = false;
    private bool isInBed = false;

    private GameObject player;
    private Rigidbody2D rb;
    private CharacterController playerController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<CharacterController>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bed") && !isSleeping)
        {
            Debug.Log("Press E to sleep");
            isInBed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bed"))
        {
            Debug.Log("Player left the bed");
            isInBed = false;

        }
    }
    void OnInteract(InputValue value)
    {
        if (isInBed && !isSleeping)
        { 
            StartCoroutine(Sleep());
        }
    }

    IEnumerator Sleep()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject Bed = GameObject.FindGameObjectWithTag("Bed");
        isSleeping = true;
         
        if (playerController != null)
        {
            playerController.enabled = false;
        }
        
        Player.transform.position = Bed.transform.position;
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Player is sleeping");
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        rb.constraints |= RigidbodyConstraints2D.FreezeRotation;

        yield return new WaitForSeconds(sleepDuration);

        rb.constraints = RigidbodyConstraints2D.None;
        Debug.Log("Player woke up");
        isSleeping = false;

        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }
}