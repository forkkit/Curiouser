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
    public GameObject doNotPassOverlay; // The canvas holding the out-of-bounds message
    public float fadeDuration = 0.2f; // Duration in seconds of UI fade
    private bool outOfBounds = false;
    private CanvasGroup canvasOutOfBounds;

    // Start is called before the first frame update
    void Start()
    {
        aliceController = alice.GetComponent<AliceController>();
        canvasOutOfBounds = doNotPassOverlay.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        // Manage fading/in out of out-of-bounds message
        if (!outOfBounds)
        {
            if (canvasOutOfBounds.alpha > 0)
                canvasOutOfBounds.alpha -= Time.deltaTime / fadeDuration; 
        }
        else
        {
            if (canvasOutOfBounds.alpha < 1)
                canvasOutOfBounds.alpha += Time.deltaTime / fadeDuration;
        }
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

    IEnumerator ManageFade()
    {
        CanvasGroup canvasG = doNotPassOverlay.GetComponent<CanvasGroup>();
        if (outOfBounds)
        {
            while (canvasG.alpha > 0)
            {
                canvasG.alpha -= Time.deltaTime; 
                yield return null;
            }
        }
        else
        {
            while (canvasG.alpha < 1)
            {
                canvasG.alpha += Time.deltaTime;
                yield return null;
            }
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
        if (other.gameObject.CompareTag("Do Not Pass"))
        {
            outOfBounds = true;
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
    }

    private void OnTriggerExit(Collider other)
    {
        bottleSource.StopAndResetBottleSound();
        cakeSource.StopRequestingBiteSound();
        if (other.gameObject.CompareTag("Do Not Pass")) {
            outOfBounds = false;
        }
    }
}
