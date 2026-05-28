using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1_3Effect : MonoBehaviour,IEffect
{
    [SerializeField] private GameObject obj;
    public void ActivateEffect()
    {
        obj.SetActive(true);
    }
}
