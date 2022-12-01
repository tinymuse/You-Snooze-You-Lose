using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Countdown : MonoBehaviour
{
    public GameObject countdown;
    public GameObject gameCanvas;
    public GameDifficulty countdownTimer;
    public BarToggle energyBar;

 public void CountdownStart()
    {
        StartCoroutine(playCountdown());
    }

    IEnumerator playCountdown()
    {
        print("startcountdown");


        yield return new WaitForSeconds(1f);
        SoundManager.PlaySound("countdownSlow");
        countdown.SetActive(true);
        yield return new WaitForSeconds(2f);
        SoundManager.StopSound("countdownSlow");
        yield return new WaitForSeconds(2f);

        gameCanvas.SetActive(true);
        countdownTimer.secondsRemaining = countdownTimer.maxSeconds;
        energyBar.currentEnergy = energyBar.maxEnergy;
        countdown.SetActive(false);
    }
}
