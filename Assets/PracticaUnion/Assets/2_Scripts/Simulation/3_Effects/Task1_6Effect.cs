using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Task1_6Effect : MonoBehaviour, IEffect
{
    [SerializeField] private GameObject patient;
    private int animation1_6;
    private Animator animator;

    private bool change = false;
    private float changePerSecond = 1f;

    [SerializeField] private Rig rig;

    private void Awake()
    {
        animation1_6 = Animator.StringToHash("T-1-6");
        animator = patient.GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        if (change)
        {
            rig.weight -= changePerSecond * Time.deltaTime;
            if ((rig.weight == 0))
            {
                change = false;
            }
        }
    }



    public void ActivateEffect()
    {
        change = true;
        animator.CrossFade(animation1_6, 0.15f);
    }
}
