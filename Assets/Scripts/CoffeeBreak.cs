using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoffeeBreak : MonoBehaviour
{
    public GameObject keyPositions;
    public GameObject coffeeObject;
   // public GameDifficulty countdownTimer;
   // public BarToggle energyBar;
    public GameObject coffeeBar;
    public float maxCoffee;
    public float currentCoffee;
    public MusicController musicController;
    public GameObject gameScreen;
    public GameObject energyBar;
    public GameObject countdownTimer;
    public GameObject coffeeCountdown;
    public AudioSource audioSource;
    public float originalPitchLevel;
    public GameObject noPoints;
    public GameObject decentPoints;
    public GameObject greatPoints;


    public RandomDialogue randomDialogue;

    // Start is called before the first frame update
    private void OnEnable()
    {
        
        randomDialogue.StopAllCoroutines();
        countdownTimer.GetComponent<GameDifficulty>().stopTimer = true;
        countdownTimer.SetActive(false);
        originalPitchLevel = audioSource.pitch;
        StartCoroutine(CoffeePour());
        currentCoffee = 0;
        coffeeBar.SetActive(true);
        coffeeBar.GetComponent<HealthBar>().SetMaxHealth(maxCoffee);
        gameScreen.SetActive(true);
        energyBar.SetActive(false);


    }

    IEnumerator CoffeePour()
    {
        GameObject[] speechObjects;
        speechObjects = GameObject.FindGameObjectsWithTag("Speech");

        foreach (GameObject gameObject in speechObjects)
        {
            gameObject.SetActive(false);
        }

        SoundManager.PlaySound("alarm");
        audioSource.pitch = 2;



        yield return new WaitForSeconds(2);
        keyPositions.SetActive(true);
        coffeeObject.SetActive(true);
        coffeeCountdown.SetActive(true);


        yield return new WaitForSeconds(10f);


        if (currentCoffee <= 5)
            {
                print("badpour");
            noPoints.SetActive(true);
                energyBar.GetComponent<BarToggle>().currentEnergy -= 0;
            SoundManager.StopSound("pourCoffee");
            SoundManager.PlaySound("badCoffee");
        }
            if (currentCoffee > 5 && currentCoffee <= 10)
            {
                print("decentpour");
            decentPoints.SetActive(true);
                energyBar.GetComponent<BarToggle>().currentEnergy += 5;
            SoundManager.StopSound("pourCoffee");
            SoundManager.PlaySound("drinkCoffee");
        }
            if (currentCoffee > 10)
            {
            greatPoints.SetActive(true);
            print("greatpour");
                energyBar.GetComponent<BarToggle>().currentEnergy += 10;
            SoundManager.StopSound("pourCoffee");
            SoundManager.PlaySound("drinkCoffee");
        }
            countdownTimer.GetComponent<GameDifficulty>().stopTimer = false;
            keyPositions.SetActive(false);
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("Arrow");

            foreach (GameObject gameObject in gameObjects)
            {
                Destroy(gameObject);
            }
            gameScreen.SetActive(false);
        countdownTimer.SetActive(true);
        energyBar.SetActive(true);
            randomDialogue.StartRandomDialogue();
 

        coffeeObject.SetActive(false);
        coffeeCountdown.SetActive(false); 
        coffeeBar.SetActive(false);
            audioSource.pitch = originalPitchLevel;

        yield return new WaitForSeconds(3);
        noPoints.SetActive(false);
        decentPoints.SetActive(false);
        greatPoints.SetActive(false);
        this.gameObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        coffeeBar.GetComponent<HealthBar>().SetHealth(currentCoffee);

    }
}
