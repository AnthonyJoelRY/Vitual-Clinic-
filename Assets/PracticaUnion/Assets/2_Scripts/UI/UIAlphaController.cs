using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAlphaController : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    private bool activeCanvas = true;
    public void ChangeAlpha()
    {
        if (activeCanvas)
        {
            LeanTween.alphaCanvas(canvasGroup.GetComponent<CanvasGroup>(), 1, 2f);
        }
        else
        {
            LeanTween.alphaCanvas(canvasGroup.GetComponent<CanvasGroup>(), 0, 2f);
        }
        activeCanvas = !activeCanvas;
    }
}
