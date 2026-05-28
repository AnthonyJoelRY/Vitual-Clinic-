using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private InputAction pauseAction;
    public static bool gameIsPaused = false;
    [SerializeField] bool pauseOnStart;
    [SerializeField] UIPanelController1 pauseUI;
    [SerializeField] public PlayerController playerController;



    private void OnEnable()
    {
        //pauseAction.performed += _ => ActivePauseAction();
    }



    private void OnDisable()
    {
        //pauseAction.performed -= _ => ActivePauseAction();
    }

    private void Awake()
    {
        pauseAction = playerInput.actions["Pause"];
    }

    // Start is called before the first frame update
    void Start()
    {
        if (pauseOnStart)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.enabled = true;
        //pauseUI.ActivateFast();
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.enabled = true;
        //pauseUI.DeactivateAll();
    }



    public void DeactivatePause()
    {
        ResumeGame();
        pauseUI.DeactivateAllFast();
    }

    private void ActivePauseAction()
    {
        PauseGame();
        pauseUI.ActivateFast();
    }
}
