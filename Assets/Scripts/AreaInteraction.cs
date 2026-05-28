using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class AreaInteraction : MonoBehaviour
{
    private UiInteraction mUiInteracion;
    private ReceptorInteraction mActualReceptor;
    public AudioSource sonidoInicial;
    public PreguntasManager preguntasManager;
    public int contadorAudio = 0;

    CursorController cc;

    [SerializeField] GameObject UI;
    [SerializeField] VideoPlayer vp;

    [SerializeField] string urlVideo;

    bool mCanInteract = false;

    [SerializeField] bool desactiveOnEnter;

    [SerializeField] GameObject objects;
    // opcional
    [SerializeField] GameObject salaOpciones;

    private void Start()
    {
        mActualReceptor = gameObject.GetComponent<ReceptorInteraction>();
        mUiInteracion = GameObject.FindGameObjectWithTag("UI IArea").GetComponent<UiInteraction>();
        cc = GameObject.FindObjectOfType<CursorController>();
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& mCanInteract)
        {
            if (!salaOpciones.activeSelf)
            {
                salaOpciones.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                
                salaOpciones.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }
    }


    private void ActivateUIActions()
    {
        
        if (mActualReceptor != null)
        {
            if (mActualReceptor.isArea)
            {
                
                objects.SetActive(true);
                cc.ShowCursor();
                preguntasManager.ReiniciarJuego();

            }
        }
    }

   
    public void DesactivateUIActions()
    {
        salaOpciones.SetActive(false);
        if(objects != null ){
            objects.SetActive(false);
        }
        cc.HideCursor();
        Cursor.lockState = CursorLockMode.Locked;
         
    }

    
    public void desplegarVideos()
    {
        mActualReceptor.Activate();
        salaOpciones.SetActive(false);
         
    }
    public void desplegarPreguntas()
    {
        salaOpciones.SetActive(false);
        objects.SetActive(false);
        ActivateUIActions();
         
    }
    public void desplegarAudio()
    {
        if (sonidoInicial.isPlaying)
        {
            sonidoInicial.Stop();
        }
        else
        {
            sonidoInicial.Play();
        }
    }

     public void desplegarPracticas()
    {
        salaOpciones.SetActive(false);
        SceneManager.LoadScene("0-StartMenu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag.Equals("Player")&&!desactiveOnEnter ) //&& objects != null
        {
            mActualReceptor = gameObject.GetComponent<ReceptorInteraction>();
            mUiInteracion.Activate(gameObject.GetComponent<ReceptorInteraction>().GetInteractionMessage());
            mCanInteract = true;
        }
        else
        {
            mUiInteracion.Deactivate();
            mCanInteract = false;
        }
        if(contadorAudio <1 && sonidoInicial != null){
            sonidoInicial.Play();
            contadorAudio++;
        }
    }
        
    private void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag.Equals("Player"))
        {
            if(sonidoInicial != null){
                sonidoInicial.Stop();
            }
            
            mUiInteracion.Deactivate();
            mCanInteract = false;
        }
    }

    

}
