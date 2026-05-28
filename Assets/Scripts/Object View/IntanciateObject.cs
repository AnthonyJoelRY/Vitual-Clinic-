using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntanciateObject : MonoBehaviour,IAction
{
    [SerializeField] GameObject position;
    [SerializeField] ViewController VC;
    public void Activate()
    {
        GameObject newObject = Instantiate(gameObject) as GameObject;
        newObject.transform.position = position.transform.position;
        VC.newObject = newObject;
        position.GetComponentInChildren<ObjectViewer>().targetObject = newObject.transform;

    }

}
