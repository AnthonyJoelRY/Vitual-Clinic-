using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1_13Interaction : MonoBehaviour
{

    [SerializeField] GameObject pivotPointer;
    [SerializeField] AudioSource bulbAudio;
    private float presureLimitValue;
    private float presureValue = 0;

    [SerializeField] GameObject bloodPresureObj;
    Vector3 bloodPresureTransform;
    Vector3 increaseVector = new Vector3(0.01f, 0.01f, 0.01f);


    private void Start()
    {
        presureLimitValue = Converter(-180);
        
    }
    public void ShowDialogueUI()
    {
        
        //Aumentar el tamaño del objeto del tensiometro en base al vector de incremento
        bloodPresureTransform = bloodPresureObj.transform.localScale;
        bloodPresureTransform += increaseVector;


        if (presureValue >= presureLimitValue)
        {
            //Aumentar el valor de la aguja del tensiomentro un valor entre 16 y 20 grados 
            presureValue -= Random.Range(Converter(16), Converter(20)); 
            LeanTween.rotateZ(pivotPointer, presureValue, 0.3f);
            //Disminur el valor entre 2 y 4 
            presureValue += Random.Range(Converter(2), Converter(4));
            LeanTween.rotateZ(pivotPointer, presureValue, 0.1f).setDelay(0.3f);
            //Reproducir audio de la valvula
            bulbAudio.Play();
            //Aumentar de tamaño al brazalete del tensiometro
            bloodPresureObj.LeanScale(bloodPresureTransform, 1f);
        }
        else
        {
            LeanTween.rotateZ(pivotPointer, Converter(-180), 0.6f);
            presureValue = Converter(-85);
            gameObject.GetComponent<NextTaskInteraction>().DequeueTask();
            
        }       
    }

    //Convierte el numero de grados deseados a los milimimetros de mercurio de la UI
    public float Converter(float presureValue)
    {
        float fixValue = (presureValue * 360)/320;
        return fixValue;
    }


}
