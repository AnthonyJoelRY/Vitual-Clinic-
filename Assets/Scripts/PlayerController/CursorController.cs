using UnityEngine;


public class CursorController : MonoBehaviour
{
    PlayerController playerController;

    void Awake()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        HideCursor();
    }

    //Esconder cursor en juego
    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.enabled = true;
        
    }

    //Mostrar cursor en juego
    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.enabled = false;

    }
}
