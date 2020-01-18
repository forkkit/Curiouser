using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 spawnPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respawn() {
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = spawnPosition;
    }
}
