using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCM : MonoBehaviour
{
    public float escalaBase = 1f; // Escala inicial del corazón
    public float escalaAmplitud = 0.1f; // Amplitud de la oscilación
    public float velocidadLatido = 2f; // Velocidad del latido
    public int pointsToAdd = 10;
    private float tiempoPasado = 0f;

    [SerializeField]
    private GameObject o;
    void Update()
    {
        tiempoPasado += Time.deltaTime * velocidadLatido; // Incrementa el tiempoPasado

        // Calcula la nueva escala basada en la funcion seno
        float nuevaEscala = escalaBase + escalaAmplitud * Mathf.Sin(tiempoPasado);

        // Aplica la nueva escala al transform del objeto
        transform.localScale = new Vector3(nuevaEscala, nuevaEscala, nuevaEscala);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(pointsToAdd);
            }
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        o.GetComponent<IAction>().Activate();
    }
}


