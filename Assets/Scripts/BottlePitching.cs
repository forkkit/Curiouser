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
        StartCoroutine(DelayPitchUp());
    }

    public void StopAndResetBottleSound()
    {
        aSource.Stop();

        aSource.pitch = 1;
    }

    IEnumerator DelayPitchUp()
    {
        yield return new WaitForSeconds(delayBeforePitchUpTime);
        pitchingUp = true;
    }

    IEnumerator PitchUp()
    {
        while (alwaysTrue)
        {
            if (pitchingUp)
            {
                aSource.pitch += pitchUpSpeed * Time.deltaTime;
            }
            else
            {
                aSource.pitch = 1;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
