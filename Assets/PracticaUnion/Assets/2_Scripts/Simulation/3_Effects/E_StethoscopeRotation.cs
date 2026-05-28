using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_StethoscopeRotation : MonoBehaviour, IEffect
{
    [SerializeField] GameObject stethoscopeObj;
    public void ActivateEffect()
    {
        stethoscopeObj.LeanRotateZ(26.1f, 1f);          
    }
}
