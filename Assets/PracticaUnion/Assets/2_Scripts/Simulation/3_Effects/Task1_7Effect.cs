using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task1_7Effect : MonoBehaviour,IEffect
{
    [SerializeField] Button tensiometroBtn;


    public void ActivateEffect()
    {
        tensiometroBtn.interactable = true;
    }
}
