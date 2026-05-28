using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelController : MonoBehaviour, IAction
{
    [SerializeField] RectTransform uiPanel;
    CursorController cc;
    [SerializeField] bool activeFirst;

    private bool isEnable = true;

    void Start()
    {
        cc = GameObject.FindObjectOfType<CursorController>();


        //uiPanel.transform.localScale = new Vector3(0, 0, 0);

        uiPanel.anchoredPosition3D += new Vector3(10f, 940f, 0f);



        if (activeFirst)
        {
            ActivateFirst();
        }
    }


    public void Activate()
    {

        if (isEnable)
        {
            LeanTween.moveY(uiPanel, uiPanel.anchoredPosition3D.y + -1110f, 0.5f);

            // LeanTween.scale(uiPanel, new Vector3(1, 1, 1), 0.5f);
            cc.ShowCursor();
            isEnable = false;
        }





    }
    public void ActivateFirst()
    {


        //LeanTween.scale(uiPanel, new Vector3(1, 1, 1), 0f);
        cc.ShowCursor();


    }
    public void DesactivarTodo()
    {

        LeanTween.moveY(uiPanel, uiPanel.anchoredPosition3D.y + 1110f, 0.3f);

        //LeanTween.scale(uiPanel, new Vector3(0, 0, 0), 0.3f);
        cc.HideCursor();

        isEnable = true;

    }
    public void Desctivar()
    {
        //LeanTween.scale(uiPanel, new Vector3(0, 0, 0), 0.3f);         


    }


}
