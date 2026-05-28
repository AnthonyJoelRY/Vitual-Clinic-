using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    [SerializeField] bool pauseOnAwake;

    private void Awake()
    {
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
    }

    public void ResumePlayer()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
