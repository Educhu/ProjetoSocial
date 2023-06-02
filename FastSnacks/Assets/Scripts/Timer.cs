using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int timer;
    public TMP_Text timerText;


    void Update()
    {
        timer = timer + 1;
        DisplayTime(timer);

        //timerText.text = "Timer: " + timer;
    }

    void DisplayTime(float timeTodispl)
    {
        timeTodispl += 1;
        float minutes = Mathf.FloorToInt(timeTodispl / 60);
        float seconds = Mathf.FloorToInt(timeTodispl % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
