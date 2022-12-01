using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public TMPro.TextMeshProUGUI highScore;
    public TMPro.TextMeshProUGUI currentScore;
    public BarToggle energyBar;
    private float maxScore;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("High score"))
        {
            highScore.text = PlayerPrefs.GetFloat("High score").ToString("F0");
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (energyBar.gameEnd == true)
        {
            currentScore.text = "Score:" + " " + energyBar.finalScore.ToString("F0");
            StartCoroutine(UpdateHighScore());
        }

    }

    IEnumerator UpdateHighScore()
    {

        if (energyBar.finalScore > maxScore)
        {
            maxScore = energyBar.finalScore;
        }
        else yield break;


        if (PlayerPrefs.GetFloat("High score") > maxScore)
        {
            highScore.text = "High Score:" + " " + PlayerPrefs.GetFloat("High score").ToString("F0");
        }
        else
        {
            highScore.text = "High Score:" + " " + maxScore.ToString("F0");
        }
        yield return null;
    }

    private void OnDestroy()
    {
        savePrefs();
    }

    void savePrefs()
    {
        PlayerPrefs.SetFloat("High Score", maxScore);
        PlayerPrefs.Save();
    }
}
