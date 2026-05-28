using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour,IAction
{
    [SerializeField] string nombre;
    public void Activate()
    {
        SceneManager.LoadScene(nombre);
    }

 
}
