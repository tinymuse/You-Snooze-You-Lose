using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;

public class ButtonSelector : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject gameCredits;
    public GameObject firstButton;
    public GameObject gameInstructions;
    public GameObject audioIsOn;
    public GameObject audioIsOff;
    public Button audioButton;
    public TMP_Text audioMuteText;
    public TMP_Text audioUnMuteText;

    /* 
    public GameObject warningMainMenu;
    public GameObject levelLoader;
    public GameObject audioIsOn;
    public GameObject audioIsOff; */


    void Update()
    {
        if (gameCredits.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            gameCredits.SetActive(false);
        }
    }

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
        gameCanvas.SetActive(false);
    }


    public void StartGame()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);      
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        gameInstructions.GetComponent<GameInstructions>().StartGamePlay();
        this.gameObject.SetActive(false);
    }
    public void AudioToggle()
    {
        if (audioIsOn.activeSelf == true)
        {
            audioIsOff.SetActive(true);
            audioIsOn.SetActive(false);
            audioButton.targetGraphic = audioUnMuteText;
            AudioListener.volume = 0;
        }
        else if (audioIsOn.activeSelf == false)
        {
            audioIsOff.SetActive(false);
            audioIsOn.SetActive(true);
            audioButton.targetGraphic = audioMuteText;
            AudioListener.volume = 1;
        }

    }

    public void OpenCredits()
    {
        gameCredits.SetActive(true);
    }




    /*
    private void Update()
    {

        if (levelLoader.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            levelLoader.SetActive(false);
        }
    }
    public void ShowGameCtrls()
    {
        gameCtrls.SetActive(true);
    }

    public void ShowWarning()
    {
        warningMainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(warningButton);
    }

    

    public void ReturnToMainMenu()
    {
        GameObject.Find("ResetLevel").GetComponent<resetLevel>().backToMainMenu = true;
        SceneManager.LoadScene(0);
    }


    public void AudioToggle()
    {
        if (audioIsOn.activeSelf == true)
        {
            audioIsOff.SetActive(true);
            audioIsOn.SetActive(false);
            audioButton.targetGraphic = audioUnMuteText;
            AudioListener.volume = 0;
        }
        else if (audioIsOn.activeSelf == false)
        {
            audioIsOff.SetActive(false);
            audioIsOn.SetActive(true);
            audioButton.targetGraphic = audioMuteText;
            AudioListener.volume = 1;
        }

    }*/
}
