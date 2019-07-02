using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    public Text scoreText;
    int scorePlayer = 0;
    int maxScorePlayer;

    public Canvas canvasPause, canvasGameOver;

    // Start is called before the first frame update
    void Start()
    {
        maxScorePlayer = PlayerPrefs.GetInt("MaxScore", 0);
        scoreText.text = "Score: " + scorePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Para boton de Pausa
    public void PauseGame()
    {
        // Detener tiempo
        Time.timeScale = 0;
        // Mostrar canvas 'Pausa'
        canvasPause.enabled = true;
    }

    // Regresar de Pausa al 'Juego'
    public void BackGame()
    {
        // Continuar tiempo
        Time.timeScale = 1;
        // Cerrar canvas 'Pausa'
        canvasPause.enabled = false;
    }

    public void AddPointsScore()
    {
        // Sumar al score
        scorePlayer++;
        // Muestra en pantalla
        scoreText.text = "Score: " + scorePlayer;
    }

    // Mostar Game Over
    public void ShowGameOver()
    {
        if (scorePlayer > maxScorePlayer)
        {
            PlayerPrefs.SetInt("MaxScore", scorePlayer);
            maxScorePlayer = scorePlayer;
        }

        //Time.timeScale = 0;           <=== Detener tiempo en 'GameOver'
        canvasGameOver.enabled = true;
    }
}
