using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DoorController : MonoBehaviour
{
    public GameObject key;
    //public OVRGrabbable keyG;
    public Curiouser_AudioManager audioManager;
    public List<GameObject> toActivate;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
       // keyG = key.GetComponent<OVRGrabbable>();
    }

 
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == key)
        {
            Debug.Log("Used key!");
            m_Animator.SetTrigger("Open");
            audioManager.DoorOpened();
            Destroy(key);//keyG.m_grabbedBy.ForceRelease(keyG);
            //other.gameObject.SetActive(false);
            foreach (GameObject item in toActivate) {
                item.SetActive(true);
            }
        }
    }
}
