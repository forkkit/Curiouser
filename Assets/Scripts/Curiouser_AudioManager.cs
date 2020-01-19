using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Curiouser_AudioManager : MonoBehaviour
{
    public AudioMixerSnapshot levelMusic, endMusic;
    public AudioMixerSnapshot DoorUnopenedSnap, DoorOpenedSnap;
    public float finalTransitionTime;
    AudioSource finalStinger;
    public AudioSource gardenAmbience;

    // Start is called before the first frame update
    void Start()
    {
        finalStinger = GetComponent<AudioSource>();
        levelMusic.TransitionTo(0f);
        gardenAmbience.mute = true;
        DoorUnopenedSnap.TransitionTo(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpened()
    {
        Debug.Log("You beat the game!");
        endMusic.TransitionTo(finalTransitionTime);
        finalStinger.Play();
        gardenAmbience.mute = false;
        DoorOpenedSnap.TransitionTo(.3f);
    }
}
