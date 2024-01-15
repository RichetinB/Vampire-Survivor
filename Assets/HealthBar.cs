using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;

    void Start()
    {
        // Assure-toi que la r�f�rence au slider est d�finie
        if (healthBar == null)
        {
            healthBar = GetComponent<Slider>();
            if (healthBar == null)
            {
                Debug.LogError("Le script HealthBar n'a pas de r�f�rence � un Slider.");
            }
        }

        // Recherche automatique du script Health du joueur
        PlayerStat playerStat = FindObjectOfType<PlayerStat>();

        if (playerStat != null)
        {
            // Abonne la m�thode OnPlayerHealthChanged � l'�v�nement du joueur
            playerStat.OnHealthChanged += OnPlayerHealthChanged;

            // Initialise la barre de vie avec la vie maximale
            healthBar.maxValue = playerStat.maxHealth;
            healthBar.value = playerStat.maxHealth;
        }
        else
        {
            Debug.LogError("Le script PlayerStat n'a pas �t� trouv� dans la sc�ne.");
        }
    }

    // Cette m�thode sera appel�e chaque fois que la sant� du joueur change
    public void OnPlayerHealthChanged(int newHealth)
    {
        healthBar.value = newHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }
}

