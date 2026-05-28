using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menu;

    public GameObject indicaciones;

    public ScoreManager puntajes;



    private void Awake()
    {
        puntajes = FindObjectOfType<ScoreManager>();
        menu.SetActive(false);
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!menu.activeSelf)
            {
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                menu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }
    }


    public void abrirIndicaciones()
    {
        indicaciones.SetActive(true);
        menu.SetActive(false);
    }

    public void cerrarIndicaciones()
    {
        indicaciones.SetActive(false);
        menu.SetActive(true );
    }

    public void mejoresPuntajes()
    {
        puntajes.TogglePanel();
    }



    public void cerrarMenu()
    {
        menu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
    }
}
