using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Task1_4Effect : MonoBehaviour,IEffect
{
    [SerializeField] private GameObject patient;
    private int animation1_2;
    private Animator animator;
    


    private void Awake()
    {
        animation1_2 = Animator.StringToHash("T-1-4");
        animator = patient.GetComponent<Animator>();
    }

    public void ActivateEffect()
    {
        animator.CrossFade(animation1_2, 0.15f);
        
    }
}
