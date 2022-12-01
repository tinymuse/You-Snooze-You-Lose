using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActiveDialogue : MonoBehaviour
{
    public GameObject uiObject;
    public bool IsPlaying;
    private GameObject timelineManager;
    private PlayableDirector timeline;

    void Start()
    {
        uiObject.SetActive(false);
        timelineManager = GameObject.Find("TimelineManager");
        timeline = timelineManager.GetComponent<PlayableDirector>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (timeline.state == PlayState.Playing) return;

        
        if (collision.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);

        }
    }
}



        /*    private bool playerInRange;
            private GameObject visualCue;

            void OnTriggerEnter2D(Collider2D collision)
            {
                   if (collision.gameObject.tag == "Player")
                {
                    playerInRange = true;

                }

            }

            void OnTriggerExit2D(Collider2D collision)
            {
               if (collision.gameObject.tag == "Player")
                {
                    playerInRange = false;

                }

            }

            // Start is called before the first frame update
            void Start()
            {
                visualCue = GameObject.FindWithTag("VisualCue");
            }

            // Update is called once per frame
            void Update()
            {
                if(playerInRange)
                {
                    visualCue.SetActive(true);
                }
                else
                {
                    visualCue.SetActive(false);
                }
            } */
    
