using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameDifficulty : MonoBehaviour
{
    public float maxSeconds;
    public float secondsRemaining;
    public GameObject keysPositions;
    public TextMeshProUGUI countdownSeconds;
    public Slider slider;
    public int levelOneDepletionRate;
    public int levelTwoDepletionRate;
    public int levelThreeDepletionRate;
    public BarToggle energyBar;
    public bool gameEnd = false;
    public bool stopTimer = false;
    public GameObject coffeeCup;
    public bool secondLevelDifficulty = false;
    public bool thirdLevelDifficulty = false;

    // Start is called before the first frame update
    void Start()
    {
        maxSeconds = 60;
        secondsRemaining = maxSeconds;
        keysPositions = GameObject.Find("KeyPositions");
        slider.maxValue = maxSeconds;
        energyBar = GameObject.Find("EnergyBar").GetComponent<BarToggle>();
    }

    // Update is called once per frame
    void Update()
    {
        countdownSeconds.text = Mathf.Round(secondsRemaining).ToString();
        slider.value = secondsRemaining;

        if (stopTimer == false)
        {
            secondsRemaining -= Time.deltaTime;
            energyBar.currentEnergy -= Time.deltaTime * levelOneDepletionRate;
        }

        if (secondsRemaining <= 40 && secondsRemaining > 20 && stopTimer == false && secondLevelDifficulty == false)
        {
            //keysPositions.GetComponent<GenerateKeys>().ChangeLevel(2);
            print("2nd level of difficulty");
            secondLevelDifficulty = true;
            energyBar.currentEnergy -= Time.deltaTime * levelTwoDepletionRate;
            coffeeCup.SetActive(true);

        }
        if (secondsRemaining <= 20 && secondsRemaining > 0 && stopTimer == false && thirdLevelDifficulty == false)
        {

            //  keysPositions.GetComponent<GenerateKeys>().changeLevel = false;
            // keysPositions.GetComponent<GenerateKeys>().ChangeLevel(3);
            print("3rd level of difficulty");
            thirdLevelDifficulty = true;
            energyBar.currentEnergy -= Time.deltaTime * levelThreeDepletionRate;
                coffeeCup.SetActive(true);

        }
        if (secondsRemaining < 0)
        {
            gameEnd = true;
            secondsRemaining = 0;
        }


        
    }

}
