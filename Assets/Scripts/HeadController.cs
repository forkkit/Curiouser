using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public GameObject alice;
    public AliceController aliceController;
    // Start is called before the first frame update
    void Start()
    {
        aliceController = alice.GetComponent<AliceController>();
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
            aliceController.scale(scaleSpeed);
        }
        else if (other.gameObject.CompareTag("Drink"))
        {
            aliceController.scale(-scaleSpeed);
        }
    }
}
