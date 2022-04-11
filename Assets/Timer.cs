using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    private void Update()
    {
        int totalSeconds = (int)Time.timeSinceLevelLoad;
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
