using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AliceController : MonoBehaviour
{
    public float heightMin = 0.38f;
    public float heightMax = 2.75f;
    public Transform follow;
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

    public void scaleAround(GameObject target, Vector3 pivot, Vector3 newScale) {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;
    
        Vector3 C = A - B; // diff from object pivot to desired pivot/origin
    
        float RS = newScale.x / target.transform.localScale.x; // relative scale factor
    
        // calc final position post-scale
        Vector3 FP = B + C * RS;
    
        // finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }

    private void scaleAroundFollow(Vector3 scale) {
        scaleAround(
            this.gameObject,
            new Vector3(follow.transform.position.x, 0, follow.transform.position.z),
            scale
        );
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
        scaleAroundFollow(
            clampVector3(
                this.transform.localScale + Vector3.one * amount,
                this.heightMin,
                this.heightMax
            )
        );
    }
}
