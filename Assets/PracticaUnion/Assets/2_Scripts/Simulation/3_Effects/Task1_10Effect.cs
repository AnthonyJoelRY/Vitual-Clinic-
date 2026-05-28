using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task1_10Effect : MonoBehaviour, IEffect
{
    [SerializeField] Button estetoscopioBtn;
    

    public void ActivateEffect()
    {
        estetoscopioBtn.interactable = true;

    }
}
