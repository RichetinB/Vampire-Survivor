using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;

    public EXPbarre expBar;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 100;
        }
    }

    void Start()
    {
        expBar = GetComponent<EXPbarre>();

        UpdateExperienceBar();
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();

        UpdateExperienceBar();
    }

    void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
        }
    }

    void UpdateExperienceBar()
    {
        if (expBar != null)
        {
            expBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
            expBar.SetlevelText(level);
        }
        else
        {
            Debug.LogError("Le script EXPbarre n'a pas été trouvé sur le joueur.");
        }
    }
}
