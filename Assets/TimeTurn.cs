using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTurn : MonoBehaviour
{
    public bool turn = false;

    public float speed = 1f;

    public AudioSource aSource;

    public Transform pivot;
    Vector3 rotation = new Vector3(0, -1, 0);

    public bool sourcePlayed;

    void Update()
    {
        if(!turn){
            if(sourcePlayed){
                sourcePlayed = false;
                aSource.Stop();
            }
            return;
        
        }

        if(!sourcePlayed){
            aSource.Play();
            sourcePlayed = true;
        }

        pivot.Rotate(rotation * speed, Space.Self);

        
    }
}
