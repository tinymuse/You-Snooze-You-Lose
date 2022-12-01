using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleCountdown : MonoBehaviour
{
    public float maxSeconds;
    public float secondsRemaining;
    public TextMeshProUGUI countdownSeconds;
    public Slider slider;
    public bool playCountdown = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        maxSeconds = 10;
        slider.maxValue = maxSeconds;
        secondsRemaining = maxSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        secondsRemaining -= Time.deltaTime;
        slider.value = secondsRemaining;
        countdownSeconds.text = Mathf.Round(secondsRemaining).ToString();
        if (secondsRemaining <=3 && playCountdown == false)
        {
            SoundManager.PlaySound("countdownFast");
            playCountdown = true;
        }
        if (secondsRemaining <=0)
        {
            SoundManager.StopSound("countdownFast");
            playCountdown = false;
        }

    }
}
