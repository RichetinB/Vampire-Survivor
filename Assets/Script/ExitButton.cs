using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitApplication()
    {
        Debug.Log("quit application");
        Application.Quit();
    }
}
