using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] // This line allows the struct to appear in inspector
public struct CollisionHandler {
    public string tag;
    public UnityEvent handler;
}


public class AliceController : MonoBehaviour
{
    public List<CollisionHandler> handlers;

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
