using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDialogue : MonoBehaviour
{
    public Dialogue[] dialogues;
    private DialogueUI dialogueUI;
    public GameObject levelLoader;

    void OnEnable()
    {

        dialogueUI = GetComponent<DialogueUI>();
        ShowDialogues(dialogues);
    }

    public void ShowDialogues(Dialogue[] dialogues)
    {
        StartCoroutine(StartDialogue(dialogues));
    }

    IEnumerator StartDialogue(Dialogue[] dialogues)
    {
        yield return new WaitForSeconds(1);
        //  skipDialogueOption.SetActive(true);

        for (int i = 0; i < dialogues.Length; i++)
        // foreach (Dialogue dialogueCutscene in dialogues)

        {
            Dialogue dialogue = dialogues[i];
            dialogueUI.ShowDialogue(dialogue);
            // yield return new WaitForSeconds(delay);
            yield return new WaitUntil(() => dialogueUI.isOpen == false);
        }
        //    skipDialogueOption.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        levelLoader.GetComponent<LevelLoader>().LoadNextLevel();

    }
}

