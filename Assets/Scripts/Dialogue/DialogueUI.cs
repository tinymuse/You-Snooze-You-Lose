using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject hisSpeechDialogueBox;
    public GameObject hisThoughtDialogueBox;
    public GameObject hersSpeechDialogueBox;
    public GameObject hersThoughtDialogueBox;
    public TMP_Text titleLabel;
    public TMP_Text hisSpeechTextLabel;
    public TMP_Text hersSpeechTextLabel;
    public TMP_Text hisThoughtTextLabel;
    public TMP_Text hersThoughtTextLabel;
    private TMP_Text chosenTextLabel;
    public GameObject continueButton;
    public float xOffset;
    public float yOffset;
    private TypewriterEffect typewriterEffect;
    private ResponseHandler responseHandler;
    public bool isOpen;


    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        continueButton.SetActive(false);
        hisSpeechDialogueBox.SetActive(false);
        hisThoughtDialogueBox.SetActive(false);
        hersSpeechDialogueBox.SetActive(false);
        hersThoughtDialogueBox.SetActive(false);

    }

    public void ShowDialogue(Dialogue dialogue)
    {
        titleLabel.text = dialogue.title;
        if (titleLabel.text == "Joe Speech")
            { hisSpeechDialogueBox.SetActive(true);
        }
        else if (titleLabel.text == "Joe Thought")
        {
            hisThoughtDialogueBox.SetActive(true);
        }
        if (titleLabel.text == "Tiffany Speech")
        {
            hersSpeechDialogueBox.SetActive(true);
        }
        else if (titleLabel.text == "Tiffany Thought")
        {
            hersThoughtDialogueBox.SetActive(true);
        }
        isOpen = true;
                StartCoroutine(StepThroughDialogue(dialogue));
   
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    public void Update()
    {

        continueButton.transform.position = new Vector2(chosenTextLabel.rectTransform.position.x - xOffset, chosenTextLabel.rectTransform.position.y - yOffset);
    }

    IEnumerator StepThroughDialogue(Dialogue dialogue)
    {
        if (titleLabel.text.Contains("Joe Thought"))
        {
            chosenTextLabel = hisThoughtTextLabel;
        }
        else if (titleLabel.text.Contains("Tiffany Thought"))
        {
            chosenTextLabel = hersThoughtTextLabel;

        }
        else if (titleLabel.text.Contains("Tiffany Speech"))
        {
            chosenTextLabel = hersSpeechTextLabel;

        }
        else if (titleLabel.text.Contains("Joe Speech"))
        {
            chosenTextLabel = hisSpeechTextLabel;

        }


        for (int i = 0; i < dialogue.sentences.Length; i++)
            {
                
                continueButton.SetActive(false);
                SoundManager.PlaySound("dialoguePlaying");
                string sentence = dialogue.sentences[i];
                yield return typewriterEffect.Run(sentence, chosenTextLabel);


                if (i == dialogue.sentences.Length - 1 && dialogue.responses != null && dialogue.responses.Length > 0)
                {
                    break;
                }
                else
                {
                    continueButton.SetActive(true);
                }
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            }
        
        /*
                for (int i = 0; i < dialogue.sentences.Length; i++)
                {
                    //titleLabel.text = dialogue.title;
                    continueButton.SetActive(false);
                    SoundManager.PlaySound("dialoguePlaying");
                    string sentence = dialogue.sentences[i];
                    yield return typewriterEffect.Run(sentence, hersTextLabel);


                    if (i == dialogue.sentences.Length - 1 && dialogue.responses != null && dialogue.responses.Length > 0)
                    {
                        break;
                    }
                    else
                    {
                        continueButton.SetActive(true);
                    }
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                }
            }
        */



                /*if (i == dialogue.sentences.Length - 1 && dialogue.responses != null && dialogue.responses.Length > 0) break;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            }
                }

            if (dialogue.responses != null && dialogue.responses.Length > 0)
            {
                responseHandler.ShowResponses(dialogue.responses);
            }*/


                if (dialogue.responses != null && dialogue.responses.Length > 0)
        {
            responseHandler.ShowResponses(dialogue.responses);
        }
        else
            {
            isOpen = false;
            CloseDialogueBox();
        }
                
    }

    public void CloseDialogueBox()
    {
        continueButton.SetActive(false);
        hisSpeechDialogueBox.SetActive(false);
        hisThoughtDialogueBox.SetActive(false);
        hersSpeechDialogueBox.SetActive(false);
        hersThoughtDialogueBox.SetActive(false);
        isOpen = false;
        chosenTextLabel.text = string.Empty;
       // titleLabel.text = string.Empty;
    }



}
