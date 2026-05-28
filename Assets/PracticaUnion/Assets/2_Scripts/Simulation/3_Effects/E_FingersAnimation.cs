using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class E_FingersAnimation : MonoBehaviour, IEffect
{
    [SerializeField] private Rig rig;
    [SerializeField] private bool openAction;
    private bool changeOpen = false;
    private bool changeClose = false;
    private float changePerSecond = 2; 

    private void FixedUpdate()
    {
        if (changeOpen)
        {   
            rig.weight += changePerSecond * Time.deltaTime;
            if (rig.weight == 1)
            {
                changeOpen = false;
            }   
        }
        if (changeClose)
        {
            rig.weight -= 1 * Time.deltaTime;
            if ((rig.weight == 0))
            {
                changeClose = false;
            }
        }
    }
    public void ActivateEffect()
    {
        if (openAction)
        {
            changeOpen = true;
        }
        else
        {
            changeClose = true;
        }
    }
}
