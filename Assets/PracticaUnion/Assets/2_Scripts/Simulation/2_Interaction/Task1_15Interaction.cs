using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Task1_15Interaction : MonoBehaviour
{

    [SerializeField] GameObject valvulaPointer;

    [SerializeField] AudioSource firstSound;
    [SerializeField] AudioSource secondSound;
    [SerializeField] AudioSource tirthSound;
    [SerializeField] AudioSource fourthSound;

    [SerializeField] TextMeshProUGUI pasText;
    [SerializeField] TextMeshProUGUI padText;
    [SerializeField] TextMeshProUGUI faseText;

    [SerializeField] E_DecreassePresure decreassePresure;


    private float pressTime;
    private float fistSoundValue;

    [SerializeField] GameObject bloodPresureObj;
    Vector3 bloodPresureTransform;
    Vector3 decreaseVector = new Vector3(0.0000410f, 0.0000410f, 0.0000410f);

    private void OnEnable()
    {

        decreassePresure.ChangePresureValue(-180);
        decreassePresure.ChangeDecreaseValue(0.12f);

        Debug.Log("El presure value es " + E_DecreassePresure.presureValue);
        pressTime = 0;

        fistSoundValue = Random.Range(decreassePresure.Converter(-125), decreassePresure.Converter(-115));
    }



    private void FixedUpdate()
    {

        //Mientras los audios esten reproduciendose comenzara a aumentar el tiempo que tienen disponibles
        if ((firstSound.isPlaying || secondSound.isPlaying || tirthSound.isPlaying || fourthSound.isPlaying) && decreassePresure.PressState())
        {
            pressTime += 0.02f;
            bloodPresureTransform -= decreaseVector;
            LeanTween.scale(bloodPresureObj, bloodPresureTransform, 0.02f);
        }

        //Si el valor de la presion llega entre 120 y 110
        if (E_DecreassePresure.presureValue > fistSoundValue)
        {
            //El valor de desenso bajara a 2 por segundo
            decreassePresure.ChangeDecreaseValue(0.04f);

            //Primer sonido duracion 4s
            if (pressTime == 0 && pressTime < 4)
            {
                if (!firstSound.isPlaying)
                {
                    bloodPresureTransform = bloodPresureObj.transform.localScale;
                    firstSound.Play();
                    pasText.text = $"Pas: {(int)decreassePresure.ConvertBack(-E_DecreassePresure.presureValue)} mmhg ";
                    faseText.text = "Primera Fase";
                    Debug.Log("1" + decreassePresure.ConvertBack(E_DecreassePresure.presureValue));
                }
            }

            //Segundo sonido duracion 6.4s
            if (pressTime > 4 && pressTime < 10.4)
            {
                firstSound.Stop();
                if (!secondSound.isPlaying)
                {
                    secondSound.Play();
                    faseText.text = "Segunda Fase";
                    Debug.Log("2" +decreassePresure.ConvertBack(E_DecreassePresure.presureValue));
                }
            }

            //Tercer sonido duracion 4s
            if (pressTime > 10.4 && pressTime < 14.4)
            {
                secondSound.Stop();
                if (!tirthSound.isPlaying)
                {
                    tirthSound.Play();
                    faseText.text = "Tercera Fase";
                    Debug.Log("4" + decreassePresure.ConvertBack(E_DecreassePresure.presureValue));
                }
            }

            //Cuarto sonido duracion 3.2s 
            if (pressTime > 14.4 && pressTime < 17.7)
            {
                tirthSound.Stop();
                if (!fourthSound.isPlaying)
                {
                    fourthSound.Play();
                    faseText.text = "Cuarta Fase";
                }
            }

            //Quinto sonido duracion 
            if (pressTime > 17.7 && pressTime < 20)
            {
                fourthSound.volume = 0;
                faseText.text = "Quinta Fase";
            }

            //Fin de los sonidos 
            if (pressTime > 20 && pressTime < 21)
            {
                fourthSound.Stop();
                fourthSound.volume = 1;
                padText.text = $"Pad: {(int)decreassePresure.ConvertBack(-E_DecreassePresure.presureValue)} mmhg ";
                decreassePresure.FinishPress();
                gameObject.GetComponent<NextTaskInteraction>().DequeueTask();
                this.gameObject.SetActive(false);
            }
        }
    }



}
