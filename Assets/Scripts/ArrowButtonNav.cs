using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ArrowButtonNav : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject arrow;
    public GameObject selectedButton;
    public EventSystem currentEvent;
    public float xOffset;
    public float yOffset;
    public GameObject[] buttons;

    void Start()
    {
        //xOffset = 0.76f;
       // Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        selectedButton = firstButton;
        arrow.transform.position = new Vector2(selectedButton.GetComponent<RectTransform>().position.x - xOffset, selectedButton.GetComponent<RectTransform>().position.y - yOffset);

    }



    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(firstButton);
        currentEvent = EventSystem.current;
        selectedButton = currentEvent.currentSelectedGameObject;

        foreach (GameObject button in buttons)
            {
            if (button == selectedButton)
                {
                    selectedButton.GetComponentInChildren<TMP_Text>().color = new Color32(252, 173, 29, 255);
                }
                else
                {
                    button.GetComponentInChildren<TMP_Text>().color = new Color(0, 0, 0);
            }
        }

        arrow.transform.position = new Vector2(selectedButton.GetComponent<RectTransform>().position.x - xOffset, selectedButton.GetComponent<RectTransform>().position.y - yOffset);

        /* if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
         {
             SoundManager.PlaySound("navigationSound");
         }
        */
    }
}
