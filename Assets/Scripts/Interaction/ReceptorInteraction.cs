using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorInteraction : MonoBehaviour
{
    [SerializeField] public bool isArea;    

    [SerializeField] string interactMessage;

    [SerializeField] public GameObject[] objectsWithActions;
    


    public void Activate()
    {

        foreach (GameObject o in objectsWithActions)
        {
            o.GetComponent<IAction>().Activate();
        }

    }
    public string GetInteractionMessage()
    {
        return interactMessage;
    }


}
