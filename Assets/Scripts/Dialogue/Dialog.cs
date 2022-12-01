using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    public GameObject startButton;


    //public GameObject continueButton;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllCoroutines();
            SoundManager.StopSound("dialogueplaying");
            textDisplay.text = string.Empty;
            foreach (string sentence in sentences)
            {
                textDisplay.text += sentence + "\n\n";
                
                
            }
            startButton.SetActive(true);

        }
    }

    IEnumerator Type()
    {
        dialogBox.SetActive(true);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < sentences.Length; i++)
        {
            SoundManager.Play("dialoguePlaying");
            string sentence = sentences[i];            
            foreach (char letter in sentence)
            {
                //SoundManager.PlaySound("singleKeyPress");
                textDisplay.text += letter;
                    yield return new WaitForSeconds(typingSpeed);
            }
            textDisplay.text += "\n\n";
            

            if (i == sentences.Length - 1)
            {
                SoundManager.StopSound("dialoguePlaying");
                yield return new WaitForSeconds(1);
                startButton.SetActive(true);                
                break;
            }
            SoundManager.StopSound("dialoguePlaying");
            yield return new WaitForSeconds(1);

        }
    }
}

   /* public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);

        }
    }

}*/
