using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePitching : MonoBehaviour
{
    AudioSource aSource;
    bool pitchingUp;
    public float pitchUpSpeed;
    public float delayBeforePitchUpTime;
    bool alwaysTrue;
    bool soundPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.pitch = 1;
        alwaysTrue = true;
        pitchingUp = false;
        StartCoroutine(PitchUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBottleLoop()
    {
        aSource.Play();
        soundPlaying = true;
        StartCoroutine(DelayPitchUp());
    }

    public void StopAndResetBottleSound()
    {
        aSource.Stop();
        pitchingUp=false;
        soundPlaying = false;
        aSource.pitch = 1;
    }

    IEnumerator DelayPitchUp()
    {
        pitchingUp = false;
        //Debug.Log("Waiting a bit");
        yield return new WaitForSeconds(delayBeforePitchUpTime);
        if (soundPlaying){
        pitchingUp = true;
        //Debug.Log("Starting Pitch Up");
        }
    }

    IEnumerator PitchUp()
    {
        while (alwaysTrue)
        {
            if (pitchingUp)
            {
                if (aSource.pitch < 1.3){
                aSource.pitch = aSource.pitch + pitchUpSpeed;
                }
                //Debug.Log(aSource.pitch);
            }
            else
            {
                aSource.pitch = 1;
                //Debug.Log("No Pitch up for you!");
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
