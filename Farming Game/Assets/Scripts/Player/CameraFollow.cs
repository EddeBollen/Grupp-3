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
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, 5f, zoomSpeed * Time.deltaTime);
    }
}