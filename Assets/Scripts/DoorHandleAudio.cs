using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandleAudio : MonoBehaviour
{
    public AudioClip[] lockedDoorClips;
    AudioSource aSource;
    bool doorBeingTried;
    bool waitingForEndOfSound;
    public float minWaitTime, maxWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        doorBeingTried = false;
        waitingForEndOfSound = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (doorBeingTried && !waitingForEndOfSound)
        {
            LockedDoorSound();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        doorBeingTried = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        doorBeingTried = false;
    }

    public void RequestLockedDoorSound()
    {
        doorBeingTried = true;
    }

    public void StopRequestingBiteSound()
    {
        doorBeingTried = false;
    }

    void LockedDoorSound()
    {
        aSource.clip = lockedDoorClips[Random.Range(0, lockedDoorClips.Length)];
        aSource.pitch = Random.Range(.97f, 1.03f);
        aSource.Play();
        StartCoroutine(ResetDoorSound());
    }

    IEnumerator ResetDoorSound()
    {
        waitingForEndOfSound = true;
        yield return new WaitForSeconds(aSource.clip.length + Random.Range(minWaitTime, maxWaitTime));
        waitingForEndOfSound = false;
    }
}
