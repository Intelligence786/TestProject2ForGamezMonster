using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Attempt—ounter : MonoBehaviour
{
    public TMP_Text counterText;
    public string attermptCounterIndex = "AttemptCount";
    private int GetCounter()
    {
        if (PlayerPrefs.HasKey(attermptCounterIndex))
        {
            return PlayerPrefs.GetInt(attermptCounterIndex);
        }
        return 0;
    }

    public void SetCounter()
    {
        int savedCount = GetCounter() + 1;
        PlayerPrefs.SetInt(attermptCounterIndex, savedCount);
        counterText.text = savedCount.ToString();
    }
}
