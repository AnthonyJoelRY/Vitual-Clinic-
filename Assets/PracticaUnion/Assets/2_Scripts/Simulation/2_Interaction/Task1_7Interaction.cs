using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task1_7Interaction : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] E_MoveObject moveObject;
    [SerializeField] E_ChangeCameraValue cMPerspective;
    [SerializeField] E_ChangeObjectState changeObjectState;

    public void Execute1_7Interaction()
    {
        animator.SetBool("stay", true);
        cMPerspective.ActivateEffect();
        changeObjectState.ActivateEffect();
        moveObject.ActivateEffect();
    }






}
