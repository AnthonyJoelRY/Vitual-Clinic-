using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour,IAction
{

    bool isOpen = false;
    [SerializeField] Transform mCloseState;
    [SerializeField] Transform mOpenState;
    [SerializeField] GameObject mObjDoor;

    [SerializeField] AudioSource mSound;

    public void Activate()
    {

        if (!isOpen)
        {
         
            LeanTween.move(mObjDoor, mOpenState.position, 1F);
            
            isOpen = !isOpen;
        }
        else
        {
            LeanTween.move(mObjDoor, mCloseState.position, 1F);
           
            isOpen = !isOpen;
        }
        mSound.Play();

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
