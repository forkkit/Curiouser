using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    // Start is called before the first frame update
    public float consumeRate = 0.01f;
    float amountRemaining = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float consume() {
        this.amountRemaining -= this.consumeRate;
        if (this.amountRemaining <= 0) {
            // Remove the object from the pool
        }
        return this.amountRemaining;
    }
}
