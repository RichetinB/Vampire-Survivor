using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public int damage = 25;

    public event Action<int> OnHealthChanged;

    [HideInInspector] public Level level;


    private void Awake()
    {
        level = GetComponent<Level>();
    }

    void Start()
    {
        currentHealth = maxHealth;

        HealthBar healthBar = FindObjectOfType<HealthBar>(); 

        if (healthBar != null)
        {
            OnHealthChanged += healthBar.OnPlayerHealthChanged;

            healthBar.SetMaxHealth(maxHealth);
        }
        else
        {
            Debug.LogError("La barre de vie n'a pas �t� trouv�e dans la sc�ne.");
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealth();
    }

    void Die()
    {
        Debug.Log("Le joueur est mort !");
        Destroy(gameObject);
    }

    void UpdateHealth()
    {
        if (OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(currentHealth);
        }
    }

    

    void Update()
    {
        // Ajoute d'autres fonctionnalit�s de mise � jour ici si n�cessaire.
    }
}
