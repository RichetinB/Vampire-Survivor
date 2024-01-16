using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 100;
        }
    }
    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
        }
    }

}