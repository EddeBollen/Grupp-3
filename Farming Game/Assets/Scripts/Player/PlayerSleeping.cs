//using UnityEngine;
//using UnityEngine.InputSystem;

//public class SleepSystem : MonoBehaviour
//{
//    public float sleepDuration = 5f;
//    public Transform bedPosition;   
//    private bool isSleeping = false;

//    private GameObject player;
//    private CharacterController playerController; 

//    void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player");
//        if (player != null)
//        {
//            playerController = player.GetComponent<CharacterController>();
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player") && !isSleeping)
//        {
//            Debug.Log("Press E to sleep");
//        }
//    }
//    void OnInteract(InputValue value)
//    {
//        StartCoroutine(Sleep());
//    }

//    IEnumerator Sleep()
//    {
//        isSleeping = true;

//        if (bedPosition != null)
//        {
//            player.transform.position = bedPosition.position;
//        }

//        if (playerController != null)
//        {
//            playerController.enabled = false;
//        }

//        Debug.Log("Player is sleeping");

//        yield return new WaitForSeconds(sleepDuration);

//        Debug.Log("Player woke up");
//        isSleeping = false;

//        if (playerController != null)
//        {
//            playerController.enabled = true;
//        }
//    }
//}