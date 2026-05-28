using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class SwitchCMCamera : MonoBehaviour
{

    [SerializeField] public PlayerInput playerInput;
    [SerializeField] private int priorityBoostAmount;
    //[SerializeField] private Transform pointerObject;

    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;
    private bool isThirdPerson = true;
    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        //aimAction = playerInput.actions["Perspective"];
        aimAction = playerInput.actions["Perspective"];
    }

    private void Start()
    {
        //aimAction = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().actions["Perspective"];
        
        
    }

    private void OnEnable()
    {


        aimAction.performed += _ => SwitchPerson();

    }

    private void OnDisable()
    {

        aimAction.performed -= _ => SwitchPerson();

    }


    private void SwitchPerson()
    {
        if (isThirdPerson)
        {
            Debug.Log("Hola");
            virtualCamera.Priority += priorityBoostAmount;
        }
        else
        {
            virtualCamera.Priority -= priorityBoostAmount;
        }
        isThirdPerson = !isThirdPerson;
    }
}
