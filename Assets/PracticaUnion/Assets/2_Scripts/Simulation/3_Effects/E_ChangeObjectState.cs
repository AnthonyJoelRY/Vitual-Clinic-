using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_ChangeObjectState : MonoBehaviour, IEffect
{
    [SerializeField] GameObject[] objectsToActivate;
    [SerializeField] GameObject[] objectsToDeactivate;
    [SerializeField] Button[] objectsToInteract;
    [SerializeField] Button[] objectsToNoInteract;

    public void ChangeState(GameObject[] objects, bool state)
    {
        if (objects.Length == 0)
        {
            return;
        }
        else {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(state);
            }
        }
    }

    public void ChangeInteraction(Button[] objects, bool state)
    {
        if (objects.Length == 0)
        {
            return;
        }
        else
        {
            foreach (Button obj in objects)
            {
                obj.interactable = state;
            }
        }
    }

    //Activa o desactiva un array de objetos. 
    public void ActivateEffect()
    {
        ChangeState(objectsToActivate, true);
        ChangeState(objectsToDeactivate, false);
        ChangeInteraction(objectsToInteract, true);
        ChangeInteraction(objectsToNoInteract, false);

    }
}
