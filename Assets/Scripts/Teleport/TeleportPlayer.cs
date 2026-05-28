using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TeleportPlayer : MonoBehaviour
{

    [SerializeField] Transform[] listSpawPoints;
    [SerializeField] GameObject player;

  
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Teleport(0);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Teleport(1);
        }


    }

    public void Teleport(int i)
    {
        Vector3 aux = listSpawPoints[i].transform.position;
        player.transform.eulerAngles = listSpawPoints[i].transform.eulerAngles;
        player.transform.position = aux;

    }
}
