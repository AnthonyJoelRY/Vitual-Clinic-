using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMPerspective : MonoBehaviour
{
    private CinemachineVirtualCamera[] cinemachineVirtualCameras;

    private void Start()
    {

        cinemachineVirtualCameras = GameObject.FindObjectsOfType<CinemachineVirtualCamera>();
    }

    public void ChangeMainCamera(CinemachineVirtualCamera newCamera)
    {
        foreach (CinemachineVirtualCamera camera in cinemachineVirtualCameras)
        {
            if (camera.Priority == 10)
            {
                camera.Priority = 1;
            }
        }
        newCamera.Priority = 10;
    }
}
