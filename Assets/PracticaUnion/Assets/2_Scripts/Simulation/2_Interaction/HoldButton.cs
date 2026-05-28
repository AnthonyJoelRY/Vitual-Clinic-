using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class PointerEvent : UnityEngine.Events.UnityEvent<PointerEventData> { };
public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PointerEvent OnPointerDownEvent;
    public PointerEvent OnPointerUpEvent;
    public PointerEvent OnPointerEnterEvent;
    public PointerEvent OnPointerExitEvent;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerDownEvent != null)
            OnPointerDownEvent.Invoke(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerUpEvent != null)
            OnPointerUpEvent.Invoke(eventData);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerUpEvent != null)
            OnPointerEnterEvent.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (OnPointerUpEvent != null)
            OnPointerExitEvent.Invoke(eventData);
    }
}
