using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;

    [SerializeField] EXPbarre expBar;

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
        }
    }
}
