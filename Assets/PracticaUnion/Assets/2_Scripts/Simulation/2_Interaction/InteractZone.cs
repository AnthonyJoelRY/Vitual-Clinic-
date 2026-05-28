using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CursorChager.CursorStates cursorMode;
    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorChager.instance.ChangeCursor(cursorMode);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorChager.instance.ChangeCursor(CursorChager.CursorStates.basicHand);
    }
}
