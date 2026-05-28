using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class Task5_5Interaction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject startPoint;
    [SerializeField] GameObject endPoint;


    [SerializeField] HoldButton startEvent;
    [SerializeField] HoldButton barrierEvent;
    [SerializeField] HoldButton endEvent;

    private bool pressStart;
    private bool isInBarrier;

    private void OnEnable()
    {
        startEvent.OnPointerDownEvent.AddListener(OnPointerDown);
        startEvent.OnPointerUpEvent.AddListener(OnPointerUp);

        endEvent.OnPointerEnterEvent.AddListener(OnEndDown);

        barrierEvent.OnPointerEnterEvent.AddListener(OnEnterrBarrier);
        barrierEvent.OnPointerExitEvent.AddListener(OnExitBarrier);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StarPress();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        FinishPress();
    }
    public void StarPress()
    {
        pressStart = true;
        startPoint.GetComponent<MeshRenderer>().enabled = false;
        endPoint.SetActive(true);
        Debug.Log("Pulso en 1");
    }

    public void FinishPress()
    {
        pressStart = false;
        startPoint.GetComponent<MeshRenderer>().enabled = true;
        endPoint.SetActive(false);
        Debug.Log("Solto en 1");
    }

    public void OnEnterrBarrier(PointerEventData eventData)
    {
        isInBarrier = true;
        Debug.Log("Entro en barrier");
    }

    public void OnExitBarrier(PointerEventData eventData)
    {
        isInBarrier = false;
        FinishPress();
        Debug.Log("Salio en barrier");
    }

    public void OnEndDown(PointerEventData eventData)
    {
        if (pressStart && isInBarrier)
        {
            gameObject.GetComponent<NextTaskInteraction>().DequeueTask();   
            Debug.Log("Aguacate");  
        }
    }

}
