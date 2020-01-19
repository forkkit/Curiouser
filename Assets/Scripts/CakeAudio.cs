using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeAudio : MonoBehaviour
{
    public AudioClip[] bites;
    AudioSource aSource;
    bool biteRequested;
    bool waitingForEndOfBite;
    public float minWaitTime, maxWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        biteRequested = false;
        waitingForEndOfBite = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (biteRequested && !waitingForEndOfBite)
        {
            BiteSound();
        }
    }

    public void RequestBiteSound()
    {
        biteRequested = true;
    }

    public void StopRequestingBiteSound()
    {
        biteRequested = false;
    }

    void BiteSound()
    {
        aSource.clip = bites[Random.Range(0, bites.Length)];
        aSource.pitch = Random.Range(.97f, 1.03f);
        aSource.Play();
        StartCoroutine(ResetBite());
    }

    IEnumerator ResetBite()
    {
        waitingForEndOfBite = true;
        yield return new WaitForSeconds(aSource.clip.length + Random.Range(minWaitTime, maxWaitTime));
        waitingForEndOfBite = false;
    }
}
