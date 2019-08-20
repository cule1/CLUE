using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text timerText;
    private float time = 900;

    private bool stop = false;

    void Start()
    {
        this.gameObject.SetActive(true);
        StartCoundownTimer();
    }


    void StartCoundownTimer()
    {
        if (stop==false)
        {
            time = 900;
            timerText.text = "15:00:000";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        if (stop==false)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            string fraction = ((time * 100) % 100).ToString("000");
            timerText.text = "           " + minutes + ":" + seconds + ":" + fraction;
        }
     
    }
}












