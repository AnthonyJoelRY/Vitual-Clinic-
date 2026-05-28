using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksManager : MonoBehaviour
{
    [SerializeField]
    private int plusPoint;

    [HideInInspector] public Task task;
    [HideInInspector] public int currentTask = 0;

    private List<Task> tasksList;
    [SerializeField] DialogueUIAction dialogueUIAction;
    [SerializeField] UITweenController uITweenMenu;


    public GameObject panelSalida;

    void Awake()
    {
        tasksList = new List<Task>(); //new Queue<Task>();
        panelSalida.SetActive(false);
    }

    //Comienza con la practica, añade las tareas a una lista y procede con la primera tarea y muestra la interfaz de dialogo.
    public void StartPractice(Practice practiceData)
    {
        tasksList.Clear();
        foreach (Task task in practiceData.tasks)
            tasksList.Add(task);
            
        dialogueUIAction.ShowDialogueUI();
        NextTask();
    }

    // Ejecuta la tarea en la cola, toma la primera de la lista y presenta su dialogo e inica su efecto si posee
    public void NextTask()
    {

        //Si la lista llega a cero termina la practica
        if (tasksList.Count == currentTask)
        {
            EndPractice();
            return;
        }

        //task = tasksList.Peek();

        task = tasksList[currentTask];

        dialogueUIAction.DisplayDialogue(task.sentence);

        StartEffect(task.objectWithEffects);

        //Si la interaccion esta completa quita la tarea actual
        if (task.objectWithInteraction == null)
        {
            currentTask++;
            //task = tasksList.Dequeue();       
        }
    }

    public void StartEffect(GameObject objectWhithEffects)
    {

        if (objectWhithEffects != null)
        {
            IEffect[] effects = objectWhithEffects.GetComponents<IEffect>();
            foreach (IEffect o in effects)
            {
                o.ActivateEffect();
            }
        }
    }

    private void EndPractice()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(plusPoint);
        }
        Debug.Log("La conversacion ha terminado");
        dialogueUIAction.HideDialogueUI();
        uITweenMenu.ShowDialogueUI();

        //changeSceneAction.ChangeScene(nextScene);
        panelSalida.SetActive(true);
    }
}
