using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NextTaskInteraction : MonoBehaviour, IPointerDownHandler
{
    private TasksManager tasksManager;


    private void Start()
    {
        tasksManager = GameObject.FindObjectOfType<TasksManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (CompareTag("DesInInteraction"))
        {
            DequeueTask();
            OnPointerExit();
            gameObject.SetActive(false);
        }


    }

    public void OnPointerExit()
    {
        CursorChager.instance.ChangeCursor(CursorChager.CursorStates.basicHand);
    }

    public void DequeueTask()
    {
        if (this.gameObject.activeSelf)
        {
            tasksManager.currentTask++;
            tasksManager.NextTask();
        }
    }

    public void BackToTask(int numTask)
    {
        tasksManager.currentTask -= numTask;
    }
}
