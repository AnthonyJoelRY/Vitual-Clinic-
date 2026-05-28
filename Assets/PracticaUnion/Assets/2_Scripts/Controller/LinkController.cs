using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkController : MonoBehaviour
{
    [SerializeField] bool isInspector;
    public void Activate(string link)
    {
        if (isInspector)
        {
            Application.OpenURL(link);
        }
        else
        {
            Application.ExternalEval("window.open('" + link + "');");
        }

    }
}
