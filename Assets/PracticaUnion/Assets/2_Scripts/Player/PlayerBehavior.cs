using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] bool pauseOnAwake;
    PlayerController playerController;

    private void Awake()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        if (pauseOnAwake)
        {
            PausePlayer();
        }
        else
        {
            ResumePlayer();
        }

        
    }

    

    public void PausePlayer()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.enabled = false;
    }

    public void ResumePlayer()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.enabled = true;
    }
}
