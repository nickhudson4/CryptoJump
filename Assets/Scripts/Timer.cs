using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private bool isRunning = false;

    public float secondsElapsed = 0;

    public void StartTimer()
    {
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            secondsElapsed += Time.deltaTime;

            int minutes = ((int)secondsElapsed) / 60;
            int seconds = ((int)secondsElapsed % 60);

            text.text = Utils.IntToString(minutes) + ":" + Utils.IntToString(seconds);
        }
    }

    public void ResetTimer()
    {
        isRunning = false;
        secondsElapsed = 0;
        text.text = "0:0";
    }

    public void Pause(bool pause)
    {
        isRunning = !pause;
    }

    public void Set(bool set)
    {
        gameObject.SetActive(set);
    }
}
