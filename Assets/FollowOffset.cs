using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOffset : MonoBehaviour
{
    public Transform target;
    public Vector3 posOffset;
    public float rotOffset;


    Transform trans;

    public void Start(){
        trans = transform;
    }

    
    // Update is called once per frame
    void Update()
    {
        trans.position = target.position + posOffset;
        trans.rotation = Quaternion.Euler(new Vector3( trans.eulerAngles.x, target.eulerAngles.y + rotOffset, trans.eulerAngles.z));
    }
}
