using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Task1_2Effect : MonoBehaviour, IEffect
{

    [SerializeField] private GameObject patient;
    private int animation1_2;
    private Animator animator;

    private void Awake()
    {
        animation1_2 = Animator.StringToHash("T-1-2");
        animator = patient.GetComponent<Animator>();
    }

    public void ActivateEffect()
    {
        animator.CrossFade(animation1_2, 0.15f);
    }
}
