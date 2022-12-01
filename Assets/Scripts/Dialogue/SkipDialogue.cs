using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipDialogue : MonoBehaviour
{
    public GameObject skipDialogueButton;
    private DialogueUI dialogueUI;
    void Start()
    {
        dialogueUI = GameObject.Find("DialogueUI").GetComponent<DialogueUI>();
    }

    // Update is called once per frame
    void Update()
    {

        if (skipDialogueButton.activeSelf == true && Input.GetKeyDown(KeyCode.Return))
            {
            dialogueUI.enabled = false;
        }

    }
}
