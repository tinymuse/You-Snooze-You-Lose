using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioDistortionFilter audioDistortionFilter;
    public float speed2;
    public float speed3;
    public float distortion2;
    public float distortion3;
    public float vol2;
    public float vol3;

    public void ChangePitch(int level)
    {
        if (level == 1)
        {
            audioSource.pitch = 1;
            audioDistortionFilter.distortionLevel = 0;
            audioSource.volume = 1;
        }    
        
        
        if (level == 2)
        {
            audioSource.pitch = speed2;
            audioDistortionFilter.distortionLevel = distortion2;
            audioSource.volume = vol2;
         //   audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / speed2);
        }

        if (level == 3)
        {
            audioSource.pitch = speed3;
            audioDistortionFilter.distortionLevel = distortion3;
            audioSource.volume = vol3;
            //   audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / speed2);
        }

    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
