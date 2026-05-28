using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Collections;

public class PreguntasManager : MonoBehaviour
{
    public TextMeshProUGUI preguntaText;
    public TextMeshProUGUI respuesta1Text;
    public TextMeshProUGUI respuesta2Text;
    public TextMeshProUGUI respuesta3Text;

    [SerializeField]
    private AudioSource audioCorrecto;
    [SerializeField]
    private AudioSource audioIncorrecto;

    CursorController cc;

    public TextMeshProUGUI tiempoRestanteText;

    private int pointsToAdd = 0;

    private int pointsToSubtract = 0;
    private int quitar;

    public Button respuesta1Button;
    public Button respuesta2Button;
    public Button respuesta3Button;

    private float timerDuration; // Duracion del temporizador en segundos
    private bool isTimerRunning = false;
    private Coroutine timerCoroutine;

    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private TextAsset jsonFile; // Referencia al archivo JSON desde el inspector
    [SerializeField]
    private int totalPreguntasAMostrar = 3;

    private List<QuestionData> preguntasDisponibles = new List<QuestionData>();
    private List<QuestionData> preguntasMostradas = new List<QuestionData>();
    private int preguntaActualIndex = 0;

    private void Start()
    {
        respuesta1Button.onClick.AddListener(() => OnRespuestaSeleccionada(0));
        respuesta2Button.onClick.AddListener(() => OnRespuestaSeleccionada(1));
        respuesta3Button.onClick.AddListener(() => OnRespuestaSeleccionada(2));

        CargarPreguntasDesdeJSON();
        SeleccionarPreguntasAleatorias();
        MostrarSiguientePregunta();
    }

    private void CargarPreguntasDesdeJSON()
    {
        if (jsonFile != null)
        {
            string jsonContent = jsonFile.text;
            QuestionContainer questionContainer = JsonUtility.FromJson<QuestionContainer>(jsonContent);
            preguntasDisponibles = questionContainer.preguntas;
        }
        else
        {
            Debug.LogError("No se ha asignado un archivo JSON para cargar las preguntas.");
        }
    }
    private IEnumerator StartTimer()
    {
        isTimerRunning = true;
        float elapsedTime = 0.0f;
        
        while (elapsedTime < timerDuration)
        {
           
            yield return null;
            elapsedTime += Time.deltaTime;

            float tiempoRestante = timerDuration - elapsedTime;
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.CeilToInt(tiempoRestante % 60);

            string tiempoFormateado = minutos.ToString("00") + ":" + segundos.ToString("00");
            tiempoRestanteText.text = tiempoFormateado; // Mostrar tiempo restante

            // Cambiar el color del texto a medida que el tiempo se acerca a 0
            if (tiempoRestante <= timerDuration/2)
            {
                tiempoRestanteText.color = Color.Lerp(Color.white, Color.red, 1.0f - (tiempoRestante / (timerDuration/2)));
            }

            if (elapsedTime >= timerDuration)
            {
                
                pointsToAdd -= quitar; // Restar puntos
                // Actualizar el puntaje en la UI u otro lugar
                Debug.Log("Puntos restados: " + pointsToSubtract);

                // Reiniciar el temporizador para la siguiente pregunta
                isTimerRunning = false;
                tiempoRestanteText.color = Color.white; // Restaurar el color del texto
                if (pointsToAdd < 0)
                {
                    pointsToAdd = 0;

                }
            }
        }

        isTimerRunning = false;
        ReiniciarTemporizador(); // Reiniciar el temporizador cuando llega a 0
    }

    private void ReiniciarTemporizador()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }

        timerCoroutine = StartCoroutine("StartTimer");
    }



    private void SeleccionarPreguntasAleatorias()
    {
        List<QuestionData> preguntasAleatorias = new List<QuestionData>(preguntasDisponibles);
        preguntasMostradas.Clear();

        for (int i = 0; i < totalPreguntasAMostrar; i++)
        {
            int indiceAleatorio = Random.Range(0, preguntasAleatorias.Count);
            preguntasMostradas.Add(preguntasAleatorias[indiceAleatorio]);
            preguntasAleatorias.RemoveAt(indiceAleatorio);
        }
    }

    private void MostrarSiguientePregunta()
    {
        if (preguntaActualIndex < preguntasMostradas.Count)
        {
            QuestionData preguntaActual = preguntasMostradas[preguntaActualIndex];
            MostrarPregunta(preguntaActual);
        }
        else
        {
            // Todas las preguntas mostradas
            cc = GameObject.FindObjectOfType<CursorController>();
            cc.HideCursor();
            panel.SetActive(false);
        }
    }

    private void MostrarPregunta(QuestionData preguntaData)
    {
        preguntaText.text = preguntaData.pregunta;
        respuesta1Text.text = preguntaData.respuestas[0];
        respuesta2Text.text = preguntaData.respuestas[1];
        respuesta3Text.text = preguntaData.respuestas[2];

        pointsToAdd = preguntaData.suma;
        pointsToSubtract = preguntaData.resta;

        timerDuration = preguntaData.tiempo;
        quitar = preguntaData.quitar;

        if (isTimerRunning)
        {
            StopCoroutine(timerCoroutine);
        }

        timerCoroutine = StartCoroutine("StartTimer");
    }
        
    private bool VerificarRespuesta(int indiceRespuestaSeleccionada, QuestionData preguntaData)
    {
        return indiceRespuestaSeleccionada == preguntaData.indiceRespuestaCorrecta;
    }

    public void OnRespuestaSeleccionada(int indiceRespuestaSeleccionada)
    {
        QuestionData preguntaActual = preguntasMostradas[preguntaActualIndex];

        if (VerificarRespuesta(indiceRespuestaSeleccionada, preguntaActual))
        {
            //Debug.Log("Respuesta correcta.");
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            audioCorrecto.Play();
            if (scoreManager != null)
            {
                scoreManager.AddScore(pointsToAdd);
            }

        }
        else
        {
            //Debug.Log("Respuesta incorrecta.");
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            audioIncorrecto.Play();
            if (scoreManager != null)
            {
                scoreManager.AddScore(-pointsToSubtract);
            }
            

        }

        preguntaActualIndex++;
        MostrarSiguientePregunta();
    }
    public void ReiniciarJuego()
    {
        preguntaActualIndex = 0; // Reinicia el indice de la pregunta actual a 0
        ReiniciarListasDePreguntas();
        SeleccionarPreguntasAleatorias(); // Selecciona preguntas aleatorias nuevamente
        MostrarSiguientePregunta(); // Muestra la primera pregunta reiniciada
    }
    private void ReiniciarListasDePreguntas()
    {
        preguntasMostradas.Clear(); // Limpia la lista de preguntas mostradas
        preguntasDisponibles.Clear(); // Limpia la lista de preguntas disponibles
        CargarPreguntasDesdeJSON(); // Vuelve a cargar las preguntas desde el archivo JSON
    }
}

[System.Serializable]
public class QuestionData
{
    public string pregunta;
    public List<string> respuestas;
    public int indiceRespuestaCorrecta;
    public int suma; // Agregamos el campo "suma"
    public int resta; // Agregamos el campo "resta"
    public int tiempo;
    public int quitar;
}

[System.Serializable]
public class QuestionContainer
{
    public List<QuestionData> preguntas;
}
