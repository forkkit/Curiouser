using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DoorController : MonoBehaviour
{
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Debug.Log("Used key!");
            m_Animator.SetTrigger("Open");
        }
    }
}
