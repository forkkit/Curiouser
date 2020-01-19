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

    // Start is called before the first frame update
    void Start()
    {
        levelMusic.TransitionTo(0f);
        DoorUnopenedSnap.TransitionTo(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpened()
    {
        endMusic.TransitionTo(finalTransitionTime);
        finalStinger.Play();
        DoorOpenedSnap.TransitionTo(.3f);
    }
}
