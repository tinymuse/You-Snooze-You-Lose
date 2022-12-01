using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarToggle : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject gameCanvas;
    public GameObject youWin;
    private GameDifficulty countdownTimer;
    public float maxEnergy;
    public float currentEnergy;
    public HealthBar energyBar;
    public Animator joeAnimator;
    public MusicController musicController;
    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public bool gameEnd = false;
    public float finalScore;
    public RandomDialogue randomDialogue;

    // Start is called before the first frame update
    void Start()
    {
        energyBar.SetMaxHealth(maxEnergy);
        joeAnimator = GameObject.Find("Joe").GetComponent<Animator>();
        countdownTimer = GameObject.Find("CountdownTimer").GetComponent<GameDifficulty>();


    }

    void OnEnable()
    {
        level1 = false;
        level2 = false;
        level3 = false;
        gameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.SetHealth(currentEnergy);        

        joeAnimator.SetFloat("Energy", currentEnergy);

        if (currentEnergy >= 0.67 * maxEnergy && level1 == false)
        {
            level1 = true;
            level2 = false;
            level3 = false;
            print("Sleepy1");
            musicController.ChangePitch(1);
            joeAnimator.SetBool("Level1", true);
            joeAnimator.SetBool("Level2", false);
            joeAnimator.SetBool("Level3", false);


        }

        if (currentEnergy < 0.67 * maxEnergy && currentEnergy > 0.33 * maxEnergy && level2 == false)
        {
            level2 = true;
            level1 = false;
            level3 = false;
            print("Sleepy2");
            joeAnimator.SetBool("Level1", false);
            joeAnimator.SetBool("Level3", false);
            joeAnimator.SetBool("Level2", true);
            StartCoroutine(yawnAfterTime());
            musicController.ChangePitch(2);

        }
        if (currentEnergy <= 0.33 * maxEnergy && level3 == false)
        {
            level3 = true;
            level1 = false;
            level2 = false;
            print("Sleepy3");
            joeAnimator.SetBool("Level1", false);
            joeAnimator.SetBool("Level2", false);
            joeAnimator.SetBool("Level3", true);
            StartCoroutine(yawnAfterTime());
            musicController.ChangePitch(3);

        }
        if (currentEnergy <=0)
        {
            //gameEnd = true;
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("Arrow");

            foreach (GameObject gameObject in gameObjects)
            {
                Destroy(gameObject);
            }

            gameOver.SetActive(true);
            randomDialogue.StopAllCoroutines();
            GameObject[] speechObjects;
            speechObjects = GameObject.FindGameObjectsWithTag("Speech");

            foreach (GameObject gameObject in speechObjects)
            {
                gameObject.SetActive(false);
            }
            gameCanvas.SetActive(false);
            joeAnimator.SetBool("Level1", false);
            joeAnimator.SetBool("Level2", false);
            joeAnimator.SetBool("Level3", false);
            joeAnimator.SetTrigger("Sleep");
        }
        if (countdownTimer.secondsRemaining <= 0 && currentEnergy >= 0)
        {
            gameEnd = true;
            finalScore = currentEnergy;
            youWin.SetActive(true);
            randomDialogue.StopAllCoroutines();
            GameObject[] speechObjects;
            speechObjects = GameObject.FindGameObjectsWithTag("Speech");

            foreach (GameObject gameObject in speechObjects)
            {
                gameObject.SetActive(false);
            }
            musicController.ChangePitch(1);
            joeAnimator.SetBool("Level1", true);
            joeAnimator.SetBool("Level2", false);
            joeAnimator.SetBool("Level3", false);
            currentEnergy = maxEnergy;
            StopAllCoroutines();
        }
    }

    IEnumerator yawnAfterTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10, 20));
            joeAnimator.SetTrigger("Yawn");
            SoundManager.PlaySound("yawn");
        }

    }
}

