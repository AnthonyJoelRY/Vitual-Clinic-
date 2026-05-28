using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] float mInteractionDistance;
    [SerializeField] GameObject mOriginRay;

    private Ray mRay;
    private bool mCanInteract;

    private ReceptorInteraction mActualReceptor;

    private UiInteraction mUiInteracion;

    private void Start()
    {
        mUiInteracion = GameObject.FindGameObjectWithTag("UI IObject").GetComponent<UiInteraction>();
    }


    private void Update()
    {
        CheckInterction();
        if (mCanInteract)
        {
            //En esta región el personaje está viendo un objeto con el que puede interactuar
            //En mi caso voy a hacer la lectura de la tecla E aquí mismo, pero esto se puede manejar de distintas formas
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                mActualReceptor.Activate();
            }

        }


    }

    private void CheckInterction()
    {
        mRay = new Ray(mOriginRay.transform.position, mOriginRay.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(mRay, out hit))
        {
            mActualReceptor = hit.transform.gameObject.GetComponent<ReceptorInteraction>();

            if (hit.distance < mInteractionDistance && mActualReceptor != null && !mActualReceptor.isArea)
            {
               

                
                    mUiInteracion.Activate(mActualReceptor.GetInteractionMessage());
                    mCanInteract = true;
                

            }
            else
            {
                mUiInteracion.Deactivate();
                mCanInteract = false;
            }


        }


    }
}

