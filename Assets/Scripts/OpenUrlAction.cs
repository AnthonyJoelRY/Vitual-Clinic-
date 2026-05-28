using UnityEngine;

public class OpenUrlAction : MonoBehaviour,IAction
{
    [SerializeField] bool isInspector;
    public string url;
    
    public void Activate()
    {
        
        Open(this.url);
    }
    public void Open(string url)
    {
        if (isInspector)
            Application.OpenURL(url);
        else
            Application.ExternalEval("window.open('" + url + "');");
    }
}
