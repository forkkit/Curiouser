using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        if (other.gameObject.GetComponent<Consumable>()) {
            Consumable consumable = other.gameObject.GetComponent<Consumable>();
            float amountRemaining = consumable.consume();
            Debug.Log($"Amount remaining: {amountRemaining}. Height: {aliceController.height}");
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
}
