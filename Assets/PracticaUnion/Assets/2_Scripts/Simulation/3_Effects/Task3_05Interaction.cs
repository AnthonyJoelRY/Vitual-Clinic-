using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class Task3_05Interaction : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI temeratureTxt;
    [SerializeField] AudioSource beepAudio;


    private void OnEnable()
    {
        StartCoroutine(ExecuteInteraction());
    }

    IEnumerator ExecuteInteraction()
    {
        yield return new WaitForSeconds(15);
        double temperatureValue = Random.Range(36.5f, 37f);
        temeratureTxt.text = Math.Round(temperatureValue, 1, MidpointRounding.AwayFromZero).ToString(); 
        beepAudio.Play();
        yield return new WaitForSeconds(1);
        beepAudio.Play();
        yield return new WaitForSeconds(1);
        beepAudio.Play();
        yield return new WaitForSeconds(1);
        beepAudio.Play();
        gameObject.GetComponent<NextTaskInteraction>().DequeueTask();
    }
}
