using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AliceController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerStay(Collider other) 
    {
        const float scaleSpeed = 0.01f;
        if (other.gameObject.CompareTag("Food"))
        {
            this.transform.localScale += Vector3.one * scaleSpeed;
        }
        else if (other.gameObject.CompareTag("Drink"))
        {
            this.transform.localScale -= Vector3.one * scaleSpeed;
        }
    }
}
