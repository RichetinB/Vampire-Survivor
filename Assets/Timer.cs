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
        // D�marre le chronom�tre automatiquement
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                // Met � jour le texte du timer � chaque mise � jour du chronom�tre
                TimerTextMesh();
            }
            else
            {
                Debug.Log("Le temps est �coul� !");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    // Met � jour le texte du timer sur le canvas
    void TimerTextMesh()
    {
        TimerText.text = "Time : " + timeRemaining.ToString("F2");
    }
}