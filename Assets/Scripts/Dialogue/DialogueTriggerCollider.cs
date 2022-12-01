using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCollider : MonoBehaviour
{
    public Dialogue dialogue;
   
    void OnTriggerStay2D(Collider2D collision)

    { 
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.Return))
        {
            FindObjectOfType<DialogueUI>().ShowDialogue(dialogue);         
               }      
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogueUI>().CloseDialogueBox();
        }
    }

}
