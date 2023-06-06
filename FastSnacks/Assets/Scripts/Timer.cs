using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer;
    public TMP_Text timerText;


    void Update()
    {
        timer = timer + 0.7f;
        DisplayTime(timer);

        //timerText.text = "Timer: " + timer;
    }

    void DisplayTime(float timeTodispl)
    {
        timeTodispl += 0.7f;
        float minutes = Mathf.FloorToInt(timeTodispl / 60);
        float seconds = Mathf.FloorToInt(timeTodispl % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
