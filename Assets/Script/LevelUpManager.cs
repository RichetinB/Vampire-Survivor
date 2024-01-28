using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] PlayerStat playerstat;
    [SerializeField] Level level;
    [SerializeField] KnifeAttack knifedmg;
    [SerializeField] WhipWeapon whipdmg;


    public void HealthAugment()
    {
    
        if (playerstat != null)
        {
            playerstat.IncreaseMaxHealth(10); 
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
  
            knifedmg.IncreaseDamage(10);
            whipdmg.IncreaseDamage(10);
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
     
            playerstat.IncreaseCurrentHealth(10);
            level.CloseLevelUpCanvas();
        }
        else
        {
            Debug.LogError("PlayerStat script is not assigned!");
        }
    }



}