using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShakeWave : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent shock;
    public UnityEvent timePass;

    [SerializeField] TextMeshProUGUI pulsoTxt;
    private bool press;
    private float pressTime = 0;
    private float shockTime = 0;
    private float shockFrecuency = 0;


    public void OnPointerDown(PointerEventData eventData)
    {
        press = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        press = false;
    }

    private void OnEnable()
    {

        int varibalePulse = Random.Range(60, 100);
        pulsoTxt.text = varibalePulse.ToString();
        Debug.Log(varibalePulse);
        shockFrecuency = (60.0f / (float)varibalePulse);
        shockTime = (shockFrecuency);
    }

    private void FixedUpdate()
    {
        if (press)
        {
            //Ejectuta un shock segun el tiempo que necesita para alcanzar al frecuencia entre 80 y 100
            if (pressTime > shockTime && pressTime < shockTime + 0.02f)
            {
                ExecuteShock();
                shockTime += shockFrecuency;
            }
            pressTime += 0.02f;

            //Cada segundo de tiempo presionado cambia la UI del reloj
            if ((pressTime - (int)pressTime) > 0.98)
            {
                timePass.Invoke();
            }
        }
        // Si ha presionado mas de 1 minuto 
        if (pressTime > 60.0f)
        {
            gameObject.GetComponent<NextTaskInteraction>().DequeueTask();
            gameObject.SetActive(false);
        }

    }

    public void ExecuteShock()
    {
        shock.Invoke();
    }

}
