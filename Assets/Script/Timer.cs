using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 300;
    public bool timerIsRunning = false;

    [SerializeField] TMPro.TextMeshProUGUI TimerText;
    public GameObject canvasWin;

    private void Start()
    {
 
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                TimerTextMesh();
            }
            else
            {
                Debug.Log("Le temps est écoulé !");
                timeRemaining = 0;
                timerIsRunning = false;
                OpenWinCanvas();
            }
        }
    }

    void TimerTextMesh()
    {
        TimerText.text = "Time : " + timeRemaining.ToString("F2");
    }

    void OpenWinCanvas()
    {
   
        canvasWin.SetActive(true);

        Time.timeScale = 0f;
    }
}
