using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInteraction : MonoBehaviour
{
    [SerializeField] private GameObject mMessagePanel;
    [SerializeField] private GameObject mMessageText;


    [SerializeField] private RectTransform mInformationLogo;

    

    private Text txtMessage;

    // Start is called before the first frame update
    void Start()
    {
        txtMessage = mMessageText.GetComponent<Text>();
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0f, 0f);
    }



    public void Activate(string message)
    {
        if (gameObject.CompareTag("UI IArea"))
        {
            StartCoroutine(ActivateAnimation(message));
        }
        else
        {

           
            LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1f, 0.1f);
            txtMessage.text = message;
        }
            
        
        
    }

    IEnumerator ActivateAnimation(string message)
    {
        txtMessage.text = message;
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 1f, 0.7f);
        yield return new WaitForSeconds(0.5f);       
        LeanTween.rotateAroundLocal(mInformationLogo, Vector3.forward, 360f, 3f).setRepeat(7);
    }


    public void Deactivate()
    {
        LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0f, 0.1f);

    }
}






