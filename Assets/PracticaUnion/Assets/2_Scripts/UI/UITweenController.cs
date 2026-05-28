using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenController : MonoBehaviour
{
    [SerializeField] RectTransform uiPanel;


    public float distanceUITween;
    public float velocityUITween;

    private float hideXPosition;
    private float showXPosition;



    private void Awake()
    {
        hideXPosition = uiPanel.anchoredPosition3D.x;
        showXPosition = uiPanel.anchoredPosition3D.x - distanceUITween;
    }

    public void ChangeState()
    {
        if (uiPanel.anchoredPosition3D.x == hideXPosition)
        {
            ShowDialogueUI();
        }
        else
        {
            HideDialogueUI();
        }
    }


    public void ShowDialogueUI()
    {
        LeanTween.moveX(uiPanel, showXPosition, velocityUITween);

    }
    public void HideDialogueUI()
    {
        LeanTween.moveX(uiPanel, hideXPosition, velocityUITween);

    }
}
