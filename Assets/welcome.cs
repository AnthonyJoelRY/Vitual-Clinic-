using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class welcome : MonoBehaviour
{
    public GameObject panel;
    public GameObject b1;
    public GameObject b2;
    void Start()
    {
        b1.SetActive(true);
        b2.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        panel.SetActive(true);
    }


    public void onClic()
    {
        b1.SetActive(false);
        b2.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panel.SetActive(false);
    }
}
