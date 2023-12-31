using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Canvas")]
    public TextMeshProUGUI timerText;

    [Header("Timer Senttings")]
    [HideInInspector]
    public float currentTimer;
    [HideInInspector]
    public bool stopTime = true;

 

    // Update is called once per frame
    void Update()
    {
        if (stopTime)
        {
            currentTimer += Time.deltaTime;
            timerText.text = currentTimer.ToString("0.0");
        }
    }

    
}
