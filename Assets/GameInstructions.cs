using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstructions : MonoBehaviour
{
    public GameObject dialogueSkip;
    public GameObject countdownStart;
    public GameDifficulty countdownTimer;
    public GameObject instructionsFirstPg;
    public GameObject instructionsNextPg;
    public RandomDialogue randomDialogue;
    private GameObject audioBGM;
    private GameObject audioHolder;
    private GameObject stateDrivenCamera;
    public BarToggle energyBar;
    public TMPro.TextMeshProUGUI highScore;
    public TMPro.TextMeshProUGUI currentScore;

    // Start is called before the first frame update
    void Start()
    {
        audioBGM = GameObject.Find("Audio");
        audioHolder = GameObject.Find("Main Camera");
        stateDrivenCamera = GameObject.Find("StateDrivenCamera");
        stateDrivenCamera.GetComponent<CinemachineSwitcher>().SwitchState();

    }

    private void OnEnable()
    {
        dialogueSkip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (instructionsNextPg.activeInHierarchy == false && Input.GetKeyDown(KeyCode.Return))
        {
            instructionsNextPg.SetActive(true);
            instructionsFirstPg.SetActive(false);
        }
       else if (instructionsNextPg.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Return))
        {
            StartGamePlay();
        }


        }

        public void StartGamePlay()
    {
        randomDialogue.StartRandomDialogue();
            audioBGM.GetComponent<BGmusic>().PauseMusic();
            audioHolder.GetComponent<AudioSource>().Play();
        energyBar.joeAnimator = GameObject.Find("Joe").GetComponent<Animator>();
        energyBar.joeAnimator.SetBool("Level1", true);
        energyBar.musicController.ChangePitch(1);
        countdownTimer.gameEnd = false;
        countdownTimer.secondLevelDifficulty = false;
        countdownTimer.thirdLevelDifficulty = false;
        countdownStart.GetComponent<Countdown>().CountdownStart();

            currentScore.text = string.Empty;
            highScore.text = string.Empty;

        this.gameObject.SetActive(false);
        instructionsNextPg.SetActive(false);
        
    }
}
