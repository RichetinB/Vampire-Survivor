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

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;

        // Assurez-vous que la sant� actuelle ne d�passe pas la nouvelle valeur maximale
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        // Mettez � jour la barre de sant� avec la nouvelle valeur maximale
        if (OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(currentHealth);
        }
    }

    public void IncreaseCurrentHealth(int amount)
    {
        currentHealth += amount;

        // Assurez-vous que la sant� actuelle ne d�passe pas la nouvelle valeur maximale
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        // Mettez � jour la barre de sant� avec la nouvelle valeur de sant� actuelle
        if (OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(currentHealth);
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    void Update()
    {
        // Ajoutez d'autres fonctionnalit�s de mise � jour ici si n�cessaire.
    }
}
