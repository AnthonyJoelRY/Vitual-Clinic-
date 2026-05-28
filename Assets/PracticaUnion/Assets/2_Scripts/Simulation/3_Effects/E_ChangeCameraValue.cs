using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class E_ChangeCameraValue : MonoBehaviour,IEffect
{
    CMPerspective cMPerspective;
    [SerializeField] CinemachineVirtualCamera newCamera;

   

    private void Start()
    {

        cMPerspective = GameObject.FindObjectOfType<CMPerspective>();   
    }

    public void ActivateEffect()
    {
        cMPerspective.ChangeMainCamera(newCamera);
    }
}
