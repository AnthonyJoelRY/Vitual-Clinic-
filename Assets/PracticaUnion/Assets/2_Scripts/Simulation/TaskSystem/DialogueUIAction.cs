using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUIAction : MonoBehaviour
{
    public RectTransform uiPanel;
    public TextMeshProUGUI dialogueText;


    //public GameObject showHideButton;
    //public TextMeshProUGUI showHideText;

    private float dialogueVelocity = 0.01f;
    private float dialogueUITween = 330f;
    private bool isIuActive;
    private float hideYPosition;
    private float showYPosition;

    private void Awake()
    {
        hideYPosition = uiPanel.anchoredPosition3D.y;
        showYPosition = uiPanel.anchoredPosition3D.y + dialogueUITween;
    }

    public void DisplayDialogue(string sentence)
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";


        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueVelocity);
            //yield return null;
        }
    }

    public void ChangeDialougeUIState()
    {

        if (isIuActive)
        {
            HideDialogueUI();
        }
        else
        {
            ShowDialogueUI();
        }

    }

    public void ShowDialogueUI()
    {
        LeanTween.moveY(uiPanel, showYPosition, 0.5f);
        isIuActive = true;
        //LeanTween.rotateZ(showHideButton, 270, 0.5f);
        //showHideText.text = "Cerrar";
    }
    public void HideDialogueUI()
    {
        LeanTween.moveY(uiPanel, hideYPosition, 0.5f);
        isIuActive = false;
        //showHideText.text = "Abrir";
        //.rotateZ(showHideButton, 90, 0.5f);

    }
}
