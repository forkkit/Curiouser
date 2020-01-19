using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DoorController : MonoBehaviour
{
    public GameObject key;
    public List<GameObject> toActivate;
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
        if (other.gameObject == key)
        {
            Debug.Log("Used key!");
            m_Animator.SetTrigger("Open");
            other.gameObject.SetActive(false);
            foreach (GameObject item in toActivate) {
                item.SetActive(true);
            }
        }
    }
}
