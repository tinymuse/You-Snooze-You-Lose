using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneDialogue : MonoBehaviour
{
    public Dialogue[] dialogues;
  //  public float delay;
    private DialogueUI dialogueUI;
    public GameObject continuePlaceholder;
    private GameObject musicManager;
    public GameObject gameInstructions;
    


    //  public GameObject skipDialogueOption;

    private void Start()
    {
        dialogueUI = GameObject.Find("DialogueUI").GetComponent<DialogueUI>();
        StartCoroutine(StartDialogue(dialogues));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllCoroutines();
            dialogueUI.StopAllCoroutines();
            dialogueUI.CloseDialogueBox();            
            gameInstructions.SetActive(true);
        }
    }

    /*
    public void ShowDialogues(Dialogue[] dialogues)
    {
        
        StartCoroutine(StartDialogue(dialogues));
    }*/

    IEnumerator StartDialogue(Dialogue[] dialogues)
    {
       
       yield return new WaitForSeconds(1);

        for (int i = 0; i < dialogues.Length; i ++)
        {
            Dialogue dialogue = dialogues[i];
            dialogueUI.ShowDialogue(dialogue);
            yield return new WaitUntil(() => dialogueUI.isOpen == false);

            // yield return new WaitForSeconds(delay);
            
        }


        gameInstructions.SetActive(true);


    }
}

