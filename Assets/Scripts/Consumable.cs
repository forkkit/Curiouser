using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Consumable : MonoBehaviour
{
    // Start is called before the first frame update
    public float consumeRate = 0.01f;
    public float shrinkRate = 0.01f;
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
        this.gameObject.transform.localScale = this.gameObject.transform.localScale - Vector3.one * shrinkRate;
        if (this.amountRemaining <= 0) {
            // Move it really far away
            Debug.Log("Item consumed!");
            this.gameObject.SetActive(false);
        }
        return this.amountRemaining;
    }
}
