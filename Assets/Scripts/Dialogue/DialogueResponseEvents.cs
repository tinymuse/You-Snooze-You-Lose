using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueResponseEvents : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private ResponseEvent[] events;

    public ResponseEvent[] Events => events;
    public Dialogue Dialogue => dialogue;

    public void OnValidate()
    {
        if (dialogue == null) return;
        if (dialogue.responses == null) return;
        if (events != null && events.Length == dialogue.responses.Length) return;

       if(events == null)
        {
            events = new ResponseEvent[dialogue.responses.Length];
        }
       else
        {
            Array.Resize(ref events, dialogue.responses.Length);
        }

       for (int i = 0; i < dialogue.responses.Length; i++)
        {
            Response response = dialogue.responses[i];

            if (events[i] != null)
            {
                events[i].name = response.responseText;
            }

            events[i] = new ResponseEvent(){ name = response.responseText };
        }

    }

}
