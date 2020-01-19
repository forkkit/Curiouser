using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTurn : MonoBehaviour
{
    public bool turn = false;

    public float speed = 1f;

    public Transform pivot;
    Vector3 rotation = new Vector3(0, -1, 0);

    void Update()
    {
        if(!turn)
            return;

        pivot.Rotate(rotation * speed, Space.Self);
    }
}
