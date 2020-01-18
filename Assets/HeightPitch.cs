using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightPitch : MonoBehaviour
{
    AliceController alCont;
    AudioSource aSource;
    public float rateOfChange, minPitch, maxPitch;
    float targetPitch;


    // Start is called before the first frame update
    void Start()
    {
        alCont = GetComponent<AliceController>();
        aSource = GetComponent<AudioSource>();
        aSource.pitch = 1f;
    }

    // Update is called once per frame
    void Update()
    {
     
        targetPitch = maxPitch - alCont.height * (maxPitch - minPitch);
        if (targetPitch-0.02f > aSource.pitch)
        {
            aSource.pitch = aSource.pitch + rateOfChange * Time.deltaTime;
            Debug.Log("Raising pitch!");
        }
        else if (targetPitch + 0.02f < aSource.pitch)
        {
            aSource.pitch = aSource.pitch - rateOfChange * Time.deltaTime;
            Debug.Log("Lowering pitch!");
        }
    }
}
