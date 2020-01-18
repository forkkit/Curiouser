using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AliceController : MonoBehaviour
{
    public float heightMin = 0.38f;
    public float heightMax = 2.75f;
    public float height {
        get { return (this.transform.localScale.y - heightMin) / (heightMax - heightMin); }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    Vector3 clampVector3(Vector3 input, float min, float max) {
        // Made this cause Vector3.ClampMagnitude only takes a maximum value
        return new Vector3(
            Mathf.Clamp(input.x, min, max),
            Mathf.Clamp(input.y, min, max),
            Mathf.Clamp(input.z, min, max)
        );
    }

    public void scale(float amount) {
        this.transform.localScale = clampVector3(
            this.transform.localScale + Vector3.one * amount,
            this.heightMin,
            this.heightMax);
    }
}
