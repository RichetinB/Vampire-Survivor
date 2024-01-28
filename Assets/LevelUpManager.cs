using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] PlayerStat playerstat;
    [SerializeField] Level level;
    [SerializeField] KnifeAttack knifedmg;

    // Cette fonction sera appel�e depuis votre bouton
    public void HealthAugment()
    {
        // V�rifie si le script PlayerStat est assign�
        if (playerstat != null)
        {
            // Appelle la fonction d'augmentation de la sant� du script PlayerStat
            playerstat.IncreaseMaxHealth(10); // Changez la valeur 10 selon vos besoins
            level.CloseLevelUpCanvas();
        }
        else
        {
            Debug.LogError("PlayerStat script is not assigned!");
        }
    }

    public void DamageAugment()
    {
        if (playerstat != null)
        {
            // Appelle la fonction d'augmentation de la sant� du script PlayerStat
            knifedmg.IncreaseDamage(10); // Changez la valeur 10 selon vos besoins
            level.CloseLevelUpCanvas();
        }
        else
        {
            Debug.LogError("PlayerStat script is not assigned!");
        }
    }
    public void AugmentCurrentHealt()
    {
        if (playerstat != null)
        {
            // Appelle la fonction d'augmentation de la sant� du script PlayerStat
            playerstat.IncreaseCurrentHealth(10); // Changez la valeur 10 selon vos besoins
            level.CloseLevelUpCanvas();
        }
        else
        {
            Debug.LogError("PlayerStat script is not assigned!");
        }
    }
}