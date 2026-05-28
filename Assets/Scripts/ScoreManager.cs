using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Proyecto26;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.Objects;
using UnityEngine.SocialPlatforms;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private DataUsers dataUsers;
    private string url_firebase = "https://virtualclinicutpl-default-rtdb.firebaseio.com/";

    Puntaje valorPuntaje = new Puntaje();


    public GameObject panel;
    public TextMeshProUGUI topScoresText;
    private void Awake()
    {
        ScoreManager[] scoreManagers = FindObjectsOfType<ScoreManager>();
        if (scoreManagers.Length > 1)
        {
            // Si hay m�s de una instancia, destruye la nueva instancia y retorna
            Destroy(gameObject);
            return;
        }

        // Si es la �nica instancia, no la destruyas
        DontDestroyOnLoad(this.gameObject);
        dataUsers = FindObjectOfType <DataUsers>();
        scoreDeFirebase();  
        panel.SetActive(false);
    }
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePanel();  
        }
    }*/

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
        if (panel.activeSelf)
        {
            DisplayTopScores();  
        }
    }


    private void DisplayTopScores()
    {
        string url = $"virtual-clinic-utpl/Usuarios";

        FirebaseDatabase.GetJSON(url, gameObject.name, "DisplayTopScores1", "DisplayErrorObject");
    }

    private void DisplayTopScores1(string data)
    {
        List<UserScore> userScores = new List<UserScore>();

        if (!string.IsNullOrEmpty(data))
        {
            Dictionary<string, object> puntajesData = MiniJSON.Deserialize(data) as Dictionary<string, object>;

            foreach (var puntajeData in puntajesData)
            {
                if (puntajeData.Value is Dictionary<string, object> userData && userData.ContainsKey("Puntaje"))
                {
                    object puntajeValue;
                    if (userData.TryGetValue("Puntaje", out puntajeValue) && puntajeValue is Dictionary<string, object>)
                    {
                        Dictionary<string, object> puntajeDict = puntajeValue as Dictionary<string, object>;
                        if (puntajeDict.ContainsKey("score") && puntajeDict["score"] is long)
                        {
                            long score = (long)puntajeDict["score"];
                            UserScore userScore = new UserScore(puntajeData.Key, (int)score);
                            userScores.Add(userScore);
                        }
                    }
                }
            }

            // A
            userScores.Sort((a, b) => b.Score.CompareTo(a.Score));

            // Display the top 5 scores in the panel text
            string topScoresTextContent = "Top 10 Scores:\n";
            for (int i = 0; i < Mathf.Min(10, userScores.Count); i++)
            {
                topScoresTextContent += $"{i + 1}- {userScores[i].Username}: {userScores[i].Score}\n";
            }

            topScoresText.text = topScoresTextContent;
        }
        else
        {
            topScoresText.text = "No hay scores disponibles.";
        }
    }



    private void DisplayErrorObject(string errorMessage)
    {
        Debug.LogError("Error ---: " + errorMessage);
    }
    public void AddScore(int points)
    {
        score += points;
        if (score < 0) score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
        valorPuntaje.score = score;

        RestClient.Put($"{url_firebase}virtual-clinic-utpl/Usuarios/{dataUsers.username}/Puntaje.json", valorPuntaje).Then(
            puntajeResponse =>
            {
                Debug.Log("Score updated successfully in the database");
                // Any additional logic after a successful update
            }
        ).Catch(
            puntajeError =>
            {
                Debug.LogError($"Error updating score: {puntajeError.Message}");
                // Any additional logic in case of an error
            }
        );
    }

    private void scoreDeFirebase()
    {
        string url = $"virtual-clinic-utpl/Usuarios/{dataUsers.username}/Puntaje";
        FirebaseDatabase.GetJSON(url, gameObject.name, "InitializeScore", "DisplayErrorObject");
    }


    private void InitializeScore(string data)
    {
        

        if (string.IsNullOrEmpty(data))
        {
            // si el scoro esta vacio se inicializa en 0
            score = 0;
        }
        else
        {
            // Deserializamos el puntjae
            Puntaje scoreContainer = JsonUtility.FromJson<Puntaje>(data);

            // Se guarda el score con el de la base de datos
            score = scoreContainer.score;
        }
        
        UpdateScoreText();
    }
}

[System.Serializable]
public class Puntaje
{
    public int score;
}

[System.Serializable]
public class UserData
{
    public Puntaje Puntaje;
}

[System.Serializable]
public class UserScore
{
    public string Username;
    public int Score;

    public UserScore(string username, int score)
    {
        Username = username;
        Score = score;
    }
}