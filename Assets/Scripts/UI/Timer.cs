using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float time = 0;
    private int seconds=0;
    private int mins=0;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (Mathf.Floor(time) > seconds)
        {
            seconds = (int)Mathf.Floor(time);
            if (seconds > 60)
            {
                mins += 1;
                seconds = 0;
                time = 0;
            }
            UpdateText();
        }
    }

    private void UpdateText()
    {
        string strMin = mins >= 10 ? mins.ToString() : $"0{mins}";
        string strSec = seconds >= 10 ? seconds.ToString() : $"0{seconds}";
        timerText.text = $"{strMin}:{strSec}";
    }
}
