//using Cinemachine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    public MovementScript movementScript;
//    [SerializeField] CinemachineVirtualCamera virtualCamera;
//    [SerializeField] float normalSize = 5f;
//    [SerializeField] float zoomedSize = 5.5f;
//    [SerializeField] float zoomSpeed = 5f;

//    private void Update()
//    {
//        if (movementScript.currentSpeed > 3)
//        {
//            virtualCamera.m_Lens.OrthographicSize = 
//            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, 5f, zoomSpeed * Time.deltaTime);

//        }
//        else
//        {
//            virtualCamera.m_Lens.OrthographicSize = normalSize;
//        }
//    }
//}