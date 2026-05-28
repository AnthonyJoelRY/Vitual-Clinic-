using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class QuestionInteraction : MonoBehaviour
{
    private UiInteraction mUiInteracion;
    private ReceptorInteraction mActualReceptor;

    [SerializeField] GameObject UI;

    bool mCanInteract = false;

    [SerializeField] bool desactiveOnEnter;

    private void Start()
    {
        mActualReceptor = gameObject.GetComponent<ReceptorInteraction>();
        mUiInteracion = GameObject.FindGameObjectWithTag("UI IArea").GetComponent<UiInteraction>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && mCanInteract)
        {
            mActualReceptor.Activate();
        }
    }

    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag.Equals("Player") && !desactiveOnEnter)
        {
            mActualReceptor = gameObject.GetComponent<ReceptorInteraction>();
            mUiInteracion.Activate(gameObject.GetComponent<ReceptorInteraction>().GetInteractionMessage());
            mCanInteract = true;
        }
        else
        {
            mUiInteracion.Deactivate();
            mCanInteract = false;
        }
    }

    private void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag.Equals("Player"))
        {
            mUiInteracion.Deactivate();
            mCanInteract = false;
        }
    }



}
