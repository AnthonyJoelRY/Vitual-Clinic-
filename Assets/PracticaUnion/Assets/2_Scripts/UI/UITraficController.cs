using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITraficController : MonoBehaviour
{
    [HideInInspector] public bool uiActive = false;

    public void Active()
    {
        uiActive = true;
    }

    public void Desactive()
    {
        uiActive = false;
    }
}
