using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteteObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject objectToRotate;
    [SerializeField] int Speed;


    void Update()
    {
        objectToRotate.transform.Rotate(0, Speed * Time.deltaTime, 0);
    }

    private void OnDisable()
    {
        LeanTween.rotateY(objectToRotate, 180, 1);
    }

}
