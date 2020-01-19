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
    public float maxTimeOutOfBounds = 3f;
    private bool outOfBounds = false;
    private CanvasGroup canvasOutOfBounds;
    private float countdown = 0;
    AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        aliceController = alice.GetComponent<AliceController>();
        canvasOutOfBounds = doNotPassOverlay.GetComponent<CanvasGroup>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Manage fading/in out of out-of-bounds message
        if (!outOfBounds)
        {
            countdown = Mathf.Clamp(countdown - Time.deltaTime, 0, maxTimeOutOfBounds);
            if (canvasOutOfBounds.alpha > 0)
                canvasOutOfBounds.alpha -= Time.deltaTime / fadeDuration; 
        }
        else
        {
            countdown += Time.deltaTime;
            if (countdown > maxTimeOutOfBounds) {
                resetScene();
            }
            if (canvasOutOfBounds.alpha < 1)
                canvasOutOfBounds.alpha += Time.deltaTime / fadeDuration;
        }
    }

    void resetScene()
    {
        Application.LoadLevel(Application.loadedLevel);
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
        if (other.gameObject.CompareTag("Win") && aliceController.height < 0.2f)
        {
            WinScreenController winScreenController = winScreenOverlay.GetComponent<WinScreenController>();
            winScreenController.fadeIn();
            aSource.Play();
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
