using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class Task1_17Interaction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] GameObject valvulaPointer;
    [SerializeField] GameObject tensiometroObj;

    [SerializeField] TextMeshProUGUI[] resultsTxt;
    [SerializeField] E_DecreassePresure decreassePresure;

    private bool execute = true;

    private void OnEnable()
    {
        decreassePresure.ChangeDecreaseValue(0.24f);
    }

    public void BackToPresure()
    {
        gameObject.GetComponent<NextTaskInteraction>().BackToTask(5);
        gameObject.GetComponent<E_ChangeObjectState>().ActivateEffect();
        gameObject.GetComponent<NextTaskInteraction>().DequeueTask();

        foreach (TextMeshProUGUI item in resultsTxt)
        {
            item.text = "";
        }
    }



    private void FixedUpdate()
    {
        if (E_DecreassePresure.presureValue > 0 && execute)
        {
            Debug.Log("Hola");
            ActivateEffect();
        }
    }
    public void ActivateEffect()
    {
        LeanTween.rotateZ(valvulaPointer, 0f, 4f);
        tensiometroObj.LeanScale(new Vector3(0.68f, 0.68f, 0.68f), 3f);
        gameObject.GetComponent<NextTaskInteraction>().DequeueTask();
        execute = false;
        decreassePresure.FinishPress();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
