using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;
    private ResponseEvent[] responseEvents;
    private GameObject responseUI;
    public bool firstResponseSelected = false;

    private DialogueUI dialogueUI;

    List<GameObject> tempResponseButtons = new List<GameObject>();

    public void Start()
    {

        dialogueUI = GetComponent<DialogueUI>();
        responseUI = responseBox.gameObject;
        responseUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);

    }

    private void Update()
    {
        
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        this.responseEvents = responseEvents;
    }


    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;

        for (int i = 0; i < responses.Length; i++)
        {
            Response response = responses[i];
            int responseIndex = i;
            /*    }

                foreach (Response response in responses) 
                {*/
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.name = "response" + i;            
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.responseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, responseIndex));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, y: responseBoxHeight);
        responseBox.gameObject.SetActive(true);

        StartCoroutine(SelectFirstResponse());
    }

    IEnumerator SelectFirstResponse()
    {
        firstResponseSelected = false;
        if (firstResponseSelected == false)
        {
            EventSystem.current.SetSelectedGameObject(GameObject.Find("response0"));
            firstResponseSelected = true;
        }
        yield return null;
    }
        
         private void OnPickedResponse(Response response, int responseIndex)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }
        tempResponseButtons.Clear();

        if (responseEvents != null && responseIndex <= responseEvents.Length)
        {
            responseEvents[responseIndex].OnPickedResponse?.Invoke();
        }

        responseEvents = null;

        if (response.dialogueObject)
        {

            dialogueUI.ShowDialogue(response.dialogueObject);
        }
        else
        {
            dialogueUI.CloseDialogueBox();
        }
    }

    /*   responseUI.SetActive(true);

      responseYesButton.SetActive(true);
      responseNoButton.SetActive(true);
     responseYesButton.GetComponent<TMP_Text>().text = dialoguetopass.yesText;
      responseNoButton.GetComponent<TMP_Text>().text = dialoguetopass.noText;
      responseYesButton.GetComponent<Button>().onClick.AddListener(() => OnPickedYes(dialoguetopass.yesOption));
      responseNoButton.GetComponent<Button>().onClick.AddListener(() => OnPickedNo(dialoguetopass.noOption)); */


}

/*
    private void OnPickedYes(Dialogue dialogue)
    {
        responseUI.SetActive(false);

        responseYesButton.SetActive(false);
        responseNoButton.SetActive(false);
                
        dialogueUI.ShowDialogue(dialogue);
        Debug.Log("dialogue.yesOption");





    }
    private void OnPickedNo(Dialogue dialogue)
    {
        responseUI.SetActive(false);

        responseYesButton.SetActive(false);
        responseNoButton.SetActive(false);

        dialogueUI.ShowDialogue(dialogue);

    }



    /*
    internal void ShowResponses(Queue<string> responses)
    {
        throw new NotImplementedException();
    }
}*/
