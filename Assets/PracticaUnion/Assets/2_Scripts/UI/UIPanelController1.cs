using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelController1 : MonoBehaviour
{
    [SerializeField] GameObject uiPanel;
    PauseController pauseController;
    [SerializeField] bool activeFirst;
    UITraficController uiTraficController;

    private void Awake()
    {

        pauseController = GameObject.FindObjectOfType<PauseController>();
        uiTraficController = GameObject.FindObjectOfType<UITraficController>();
    }
    void Start()
    {

        uiPanel.transform.localScale = new Vector3(0, 0, 0);

        if (activeFirst)
        {
            ActivateFirst();
        }
    }


    public void Activate()
    {

        if (!uiTraficController.uiActive || gameObject.CompareTag("uiTP"))
        {

            LeanTween.scale(uiPanel, new Vector3(1, 1, 1), 0.5f);
            pauseController.PauseGame();
            uiTraficController.Active();
        }

    }

    public void ActivateFast()
    {
        if (!uiTraficController.uiActive || gameObject.CompareTag("uiTP"))
        {

            LeanTween.scale(uiPanel, new Vector3(1, 1, 1), 0f);
            pauseController.PauseGame();
            uiTraficController.Active();
        }

    }
    public void ActivateFirst()
    {

        if (!uiTraficController.uiActive)
        {
            LeanTween.scale(uiPanel, new Vector3(1, 1, 1), 0f);
            pauseController.PauseGame();
            uiTraficController.Active();
        }

    }
    public void DeactivateAll()
    {
        LeanTween.scale(uiPanel, new Vector3(0, 0, 0), 0.3f);
        pauseController.ResumeGame();
        uiTraficController.Desactive();
    }

    public void DeactivateAllFast()
    {
        LeanTween.scale(uiPanel, new Vector3(0, 0, 0), 0f);
        pauseController.ResumeGame();
        uiTraficController.Desactive();
    }
    public void Deactivate()
    {
        LeanTween.scale(uiPanel, new Vector3(0, 0, 0), 0.3f);
        uiTraficController.Desactive();

    }
}
