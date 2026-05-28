using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1_14Effect : MonoBehaviour, IEffect
{
    [SerializeField] GameObject valvulaBtn;
    [SerializeField] GameObject perillaBtn;
    public void ActivateEffect()
    {
        perillaBtn.SetActive(true);
        valvulaBtn.SetActive(false);
    }
}
