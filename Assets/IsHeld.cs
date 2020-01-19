using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHeld : MonoBehaviour
{

    public float timeHit;
    public Collider hitting;
    public FollowOffset follow;
    public TimeTurn turn;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other){
        if(other.tag == "GameController"){
                hitting = other; 
                timeHit = Time.timeSinceLevelLoad;
                //Debug.Log("started a clock!" + gameObject.name);
                follow.enabled = false;
                turn.turn = true;
        }

    }

    private void OnTriggerStay(Collider other){
        if(other != hitting)
            return;

        if(Time.timeSinceLevelLoad - timeHit >= 3)
            //Debug.Log("would had reset");
            ResetScene();

    }

    private void OnTriggerExit(Collider other){
        if(other != hitting)
            return;
        
        turn.turn = false;
        timeHit = 0;
        hitting = null;
        //Debug.Log("started a clock!" + gameObject.name);
        follow.enabled = true;

    }

    void ResetScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
