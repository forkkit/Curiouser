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
    public GameObject winScreenOverlay;
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
        if (other.gameObject.CompareTag("Playable Area"))
        {
            outOfBounds = false;
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
        if (other.gameObject.CompareTag("Win"))
        {
            WinScreenController winScreenController = winScreenOverlay.GetComponent<WinScreenController>();
            winScreenController.fadeIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bottleSource.StopAndResetBottleSound();
        cakeSource.StopRequestingBiteSound();
        if (other.gameObject.CompareTag("Playable Area")) {
            outOfBounds = true;
        }
    }
}
