using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class E_DecreassePresure : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject valvulaPointer;
    [SerializeField] HoldButton holdButtonEvent;
    [SerializeField] Image wheelImgl;
    private float decreaseValue;
    private bool press = false;
    public static float presureValue;

    private void OnEnable()
    {
        holdButtonEvent.OnPointerDownEvent.AddListener(OnPointerDown);
        holdButtonEvent.OnPointerUpEvent.AddListener(OnPointerUp);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StarPress();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FinishPress();
    }

    private void FixedUpdate()
    {
        if (press)
        {
            presureValue += decreaseValue;
            LeanTween.rotateZ(valvulaPointer, presureValue, 0.02f);
        }
    }

    public void StarPress()
    {
        press = true;
        wheelImgl.color = Color.green;
    }
    public void FinishPress()
    {
        press = false;
        wheelImgl.color = Color.red;
    }
    public bool PressState()
    {
        return press;
    }
    public void ChangePresureValue(float x)
    {
        presureValue = Converter(x);
    }
    public void ChangeDecreaseValue(float x)
    {
        decreaseValue = Converter(x);
    }

    //Convierte el numero de grados deseados a los milimimetros de mercurio de la UI
    public float Converter(float presureValue)
    {
        float fixValue = (presureValue * 360) / 320;
        return fixValue;
    }

    public float ConvertBack(float fixValue)
    {
        float presureValue = (fixValue * 320) / 360;
        return presureValue;
    }
}
