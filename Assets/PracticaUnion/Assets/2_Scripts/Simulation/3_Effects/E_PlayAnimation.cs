using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PlayAnimation : MonoBehaviour, IEffect
{
    [SerializeField] private string animationName;
    private Animator animator;
    private int vpAnimation;
   

    private void Awake()
    {
        animator =  GameObject.FindGameObjectWithTag("Patient").GetComponent<Animator>();
        vpAnimation = Animator.StringToHash(animationName);
    }

    public void ActivateEffect()
    {
        animator.CrossFade(vpAnimation, 0.15f);
    }
}
