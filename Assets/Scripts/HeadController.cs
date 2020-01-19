using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HeadController : MonoBehaviour
{
    public GameObject alice;
    AliceController aliceController;
    public BottlePitching bottleSource;
    public CakeAudio cakeSource;
    public GameObject doNotPassOverlay;
    // Start is called before the first frame update
    void Start()
    {
        aliceController = alice.GetComponent<AliceController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeCollisionOverlayIn()
    {
        StartCoroutine(DoFadeIn());
    }

    public void FadeCollisionOverlayOut()
    {
        StartCoroutine(DoFadeOut());
    }

    IEnumerator DoFadeIn()
    {
        CanvasGroup canvasG = doNotPassOverlay.GetComponent<CanvasGroup>();
        while (canvasG.alpha < 1)
        {
            canvasG.alpha += Time.deltaTime; // optinal parameters 2 ,3 ,5 
            yield return null;
        }
    }

    IEnumerator DoFadeOut()
    {
        CanvasGroup canvasG = doNotPassOverlay.GetComponent<CanvasGroup>();
        while (canvasG.alpha > 0)
        {
            canvasG.alpha -= Time.deltaTime; // optinal parameters 2 ,3 ,5 
            yield return null;
        }
    }

    void OnTriggerStay(Collider other) 
    {
        const float scaleSpeed = 0.01f;
        if (other.gameObject.GetComponent<Consumable>()) {
            Consumable consumable = other.gameObject.GetComponent<Consumable>();
            float amountRemaining = consumable.consume();
            // Debug.Log($"Amount remaining: {amountRemaining}. Height: {aliceController.height}");
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

    void OnTriggerEnter(Collider other){
        if (other.gameObject.GetComponent<Consumable>()) {
            Consumable consumable = other.gameObject.GetComponent<Consumable>();
            if (other.gameObject.CompareTag("Food"))
            {
                cakeSource.RequestBiteSound();
            }
            else if (other.gameObject.CompareTag("Drink"))
            {
                bottleSource.StartBottleLoop();
            }
            
        }
        else if (other.gameObject.CompareTag("Do Not Pass")) {
            Debug.Log("Hey, don't do that!");
            FadeCollisionOverlayIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bottleSource.StopAndResetBottleSound();
        cakeSource.StopRequestingBiteSound();
        if (other.gameObject.CompareTag("Do Not Pass")) {
            Debug.Log("Ok, that's better");
            FadeCollisionOverlayOut();
        }
    }
}
