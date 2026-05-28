using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksTrigger : MonoBehaviour
{
    
    public PracticeScriptable senteceScriptable;
    public Practice practiceData;


    private void Awake()
    {
        for (int i = 0; i < practiceData.tasks.Length; i++)
        {
            practiceData.tasks[i].sentence = senteceScriptable.sentence[i];   
        }
    }

    private void Start()
    {
        TriggerTasks();
    }

    public void TriggerTasks()
    {
        FindObjectOfType<TasksManager>().StartPractice(practiceData);
    }
}
