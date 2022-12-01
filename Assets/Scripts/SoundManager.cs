using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip dialogueSound, pourSound, drinkSound, yawnSound, alarmSound, countdownSlow, countdownFast, badCoffee;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        dialogueSound = Resources.Load<AudioClip>("dialoguePlaying");
        pourSound = Resources.Load<AudioClip>("pourCoffee");
        drinkSound = Resources.Load<AudioClip>("drinkCoffee");
        yawnSound = Resources.Load<AudioClip>("yawn");
        alarmSound = Resources.Load<AudioClip>("alarm");
        countdownSlow = Resources.Load<AudioClip>("countdownSlow");
        countdownFast = Resources.Load<AudioClip>("countdownFast");
        badCoffee = Resources.Load<AudioClip>("badCoffee");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "dialoguePlaying":
                audioSrc.PlayOneShot(dialogueSound);
                break;
            case "pourCoffee":
                audioSrc.PlayOneShot(pourSound);
                break;
            case "drinkCoffee":
                audioSrc.PlayOneShot(drinkSound);
                break;
            case "yawn":
                audioSrc.PlayOneShot(yawnSound);
                break;
            case "alarm":
                audioSrc.PlayOneShot(alarmSound);
                break;
            case "countdownSlow":
                audioSrc.PlayOneShot(countdownSlow);
                break;
            case "countdownFast":
                audioSrc.PlayOneShot(countdownFast);
                break;
            case "badCoffee":
                audioSrc.PlayOneShot(badCoffee);
                break;

        }
    }



    public static void Play(string clip)
    {
        if (clip == "dialoguePlaying")
        {
            audioSrc.clip = dialogueSound;
            audioSrc.Play();
        }
        if (clip == "pourCoffee")
        {
            audioSrc.clip = pourSound;
            audioSrc.Play();
        }
        if (clip == "drinkCoffee")
        {
            audioSrc.clip = drinkSound;
            audioSrc.Play();
        }
        if (clip == "yawn")
        {
            audioSrc.clip = yawnSound;
            audioSrc.Play();
        }
        if (clip == "alarm")
        {
            audioSrc.clip = alarmSound;
            audioSrc.Play();
        }
        if (clip == "countdownSlow")
        {
            audioSrc.clip = countdownSlow;
            audioSrc.Play();
        }
        if (clip == "countdownFast")
        {
            audioSrc.clip = countdownFast;
            audioSrc.Play();
        }


    }

    public static void StopSound(string clip)
    {
        audioSrc.Stop();
    }
}




        /*
        switch (clip)
        {
            case "dialoguePlaying":
                audioSrc.Stop();
                break;
            case "pourCoffee":
                audioSrc.Stop();
                break;
            case "drinkCoffee":
                audioSrc.Stop();
                break;
            case "yawn":
                audioSrc.Stop();
                break;
            case "countdownSlow":
                audioSrc.Stop();
                break;
            case "countdownFast":
                audioSrc.Stop();
                break;

        }*/


