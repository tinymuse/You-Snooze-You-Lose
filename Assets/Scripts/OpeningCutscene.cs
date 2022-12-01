using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpeningCutscene : MonoBehaviour
{
    public PlayableDirector director;
    public AudioSource bgm;
    private GameObject eventSystem;
    private GameObject player;
    private GameObject canvas;

    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
    }


    // Update is called once per frame
    void Update()
    {
        if (director.state == PlayState.Playing)
        {
            player.GetComponent<Movement>().enabled = false;
            canvas.GetComponent<Scoring>().enabled = false;

        }    
        else if (director.state != PlayState.Playing)
        {
            player.GetComponent<Movement>().enabled = true;
            canvas.GetComponent<Scoring>().enabled = true;
            eventSystem.SetActive(true);
            bgm.enabled = true;
        }


    }
}
