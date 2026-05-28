using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1_13Effect : MonoBehaviour,IEffect
{
    [SerializeField] GameObject uiTensiometro;

    public void ActivateEffect()
    {
        uiTensiometro.SetActive(true);
    }
}
