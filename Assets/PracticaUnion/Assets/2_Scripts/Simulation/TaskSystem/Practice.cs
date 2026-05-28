using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Practice
{
    public Task[] tasks;
}

[System.Serializable]
public class Task
{
    [TextArea(3, 10)]
    public string sentence;
    public GameObject objectWithEffects;
    public GameObject objectWithInteraction;
}
