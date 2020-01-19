using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public float fadeDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }
    
    public void fadeIn()
    {
        StartCoroutine(_doFadeIn());
    }

    IEnumerator _doFadeIn()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }
    }
}
