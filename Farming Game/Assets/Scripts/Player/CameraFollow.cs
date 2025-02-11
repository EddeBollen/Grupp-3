using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public MovementScript movementScript;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float normalSize = 5f;
    [SerializeField] float zoomedSize = 8f;
    [SerializeField] float zoomSpeed = 5f;

    private void Update()
    {
        float targetSize;

        if (Input.GetKey(KeyCode.LeftShift) && movementScript.currentSpeed == movementScript.sprintSpeed)
        {
            targetSize = zoomedSize;
        }
        else
        {
            targetSize = normalSize;
        }
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetSize, zoomSpeed * Time.deltaTime);
    }
}