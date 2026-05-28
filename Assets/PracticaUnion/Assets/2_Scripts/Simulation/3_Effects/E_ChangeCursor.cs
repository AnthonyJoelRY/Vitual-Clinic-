using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ChangeCursor : MonoBehaviour, IEffect
{
    public CursorChager.CursorStates cursorMode;
    public void ActivateEffect()
    {
        CursorChager.instance.ChangeCursor(cursorMode);
        Debug.Log("Execute");
    }


}
