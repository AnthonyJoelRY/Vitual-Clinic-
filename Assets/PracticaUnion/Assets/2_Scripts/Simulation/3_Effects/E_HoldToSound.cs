using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class E_HoldToSound : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] float timeLimit;
    private bool press;
    private bool inArea;
    private float pressTime;
    private bool isTimeleft;

    public void OnPointerDown(PointerEventData eventData)
    {
        inArea = true;
        press = true;
        CursorChager.instance.ChangeCursor(CursorChager.CursorStates.instrumentCursor);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        press = false;

        if (inArea)
        {
            CursorChager.instance.ChangeCursor(CursorChager.CursorStates.selectionHand);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inArea = false;
        press = false;
    }

    private void OnEnable()
    {
        m_AudioSource.Play();
        m_AudioSource.Pause();
        pressTime = 0;
        isTimeleft = true;
        press= false;
    }

    private void OnDisable()
    {
        pressTime = 0;
        isTimeleft = true;
        press = false;
    }

    private void FixedUpdate()
    {
        if (press)
        {
            m_AudioSource.UnPause();
            pressTime += 0.02f;   
        }
        else
        {
            m_AudioSource.Pause();          
        }

        if (pressTime > timeLimit && isTimeleft)
        {
            Debug.Log("Acabo");
            m_AudioSource.Stop();
            CursorChager.instance.ChangeCursor(CursorChager.CursorStates.basicHand);
            gameObject.GetComponent<NextTaskInteraction>().DequeueTask();
            isTimeleft = false;
        }
    }


}
