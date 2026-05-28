using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotation : MonoBehaviour,IAction
{

    bool isOpen = false;

    [SerializeField] Transform mCloseState;
    [SerializeField] Transform mOpenState;
    [SerializeField] GameObject mObjDoor;

    [SerializeField] AudioSource mOpenSound;
    [SerializeField] AudioSource mCloseSound;

    public void Activate()
    {

        if (!isOpen)
        {
            LeanTween.rotateY(mObjDoor, mOpenState.eulerAngles.y, 1F);
            mOpenSound.Play();
            isOpen = !isOpen;
        }
        else
        {
            LeanTween.rotateY(mObjDoor, mCloseState.eulerAngles.y, 1F);
            mCloseSound.Play();
            isOpen = !isOpen;
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
