using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
public int level = 1;
public int experience = 0;
public int amount;
[SerializeField] EXPbarre expBar;
[SerializeField] PlayerStat playerstat;
[SerializeField] GameObject LevelUpCanvas;


    int TO_LEVEL_UP
{
    get
    {
        return level * 1000;
    }
}

void Start()
{
    expBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    expBar.SetlevelText(level);

}

public void AddExperience(int amount)
{
    Debug.Log("EXP");
    experience += amount;
    CheckLevelUp();
    expBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);

}

void CheckLevelUp()
{
    if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            expBar.SetlevelText(level);

            ShowLevelUpCanvas();
        }
    }
    void ShowLevelUpCanvas()
    {
        LevelUpCanvas.SetActive(true);
        TogglePause();
    }
    void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            // Si le jeu est déjà en pause, le remettre en marche
            Time.timeScale = 1f;
        }
        else
        {
            // Si le jeu est en cours, le mettre en pause
            Time.timeScale = 0f;
        }
    }

    public void CloseLevelUpCanvas()
    {
        LevelUpCanvas.SetActive(false);
        TogglePause();
    }
}