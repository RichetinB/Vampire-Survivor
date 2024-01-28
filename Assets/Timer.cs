using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    [SerializeField] TMPro.TextMeshProUGUI TimerText;

    private void Start()
    {
        // Démarre le chronomètre automatiquement
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                // Met à jour le texte du timer à chaque mise à jour du chronomètre
                TimerTextMesh();
            }
            else
            {
                Debug.Log("Le temps est écoulé !");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    // Met à jour le texte du timer sur le canvas
    void TimerTextMesh()
    {
        TimerText.text = "Time : " + timeRemaining.ToString("F2");
    }
}