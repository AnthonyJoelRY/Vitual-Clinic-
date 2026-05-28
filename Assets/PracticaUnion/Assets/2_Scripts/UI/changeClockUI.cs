using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class changeClockUI : MonoBehaviour
{

    public ShakeWave wave;

    string ceroMinute = "0";
    string ceroSecond = "0";

    int minute = 0;
    int second = 0;


    private void OnEnable()
    {
        wave.timePass.AddListener(AddSeconds);
    }

    [SerializeField] TextMeshProUGUI seconds;
    [SerializeField] TextMeshProUGUI minutes;


    public void AddMinutes()
    {
        minute++;
        minutes.text = ceroMinute + minute.ToString();

    }

    public void AddSeconds()
    {
        second++;

        if (second == 10)
        {
            ceroSecond = "";
        }
        if (second == 60)
        {
            second = 0;
            AddMinutes();
            ceroSecond = "0";
        }

        seconds.text = ceroSecond + second.ToString();
    }

}
