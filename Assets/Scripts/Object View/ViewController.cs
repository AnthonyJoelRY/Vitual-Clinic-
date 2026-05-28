using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour,IAction
{
    CursorController cc;
    [SerializeField] GameObject position;
    [SerializeField] GameObject interfaz;
    [SerializeField] GameObject player;
    public GameObject newObject;
    void Start()
    {  
        cc = GameObject.FindObjectOfType<CursorController>();
        position.SetActive(false);
        interfaz.SetActive(false);
    }

    public void Activate()
    {
        cc.ShowCursor();
        player.SetActive(false);
        
        position.SetActive(true);
        interfaz.SetActive(true);
        
    }

    public void actInterface()
    {

        interfaz.SetActive(true);

    }

    public void desInterface()
    {
        position.SetActive(false);
        interfaz.SetActive(false);
        player.SetActive(true);
        Destroy(newObject);
        cc.HideCursor();
        

    }

    // Start is called before the first frame update
   


    private void InstanciaObjeto(GameObject prefab)
    {
        GameObject newObject = Instantiate(prefab) as GameObject;
        newObject.transform.position = position.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
