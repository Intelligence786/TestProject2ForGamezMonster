using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private bool isStarted = false;
    private float secondsCount;
    private int minuteCount;

    public void StartTimer()
    {
        secondsCount = 0;
        minuteCount = 0;
        isStarted = true;
    }

    public void StopTimer()
    {
        isStarted = false;
        timerText.text = minuteCount + ":" + (int)secondsCount;
    }

    void Update()
    {
        if (isStarted)
            UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;

        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
    }
}
