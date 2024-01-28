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
    public GameObject canvasLose;

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
            Debug.LogError("La barre de vie n'a pas été trouvée dans la scène.");
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
        canvasLose.SetActive(true);
        Time.timeScale = 0f;
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

        currentHealth = Mathf.Min(currentHealth, maxHealth);

        if (OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(currentHealth);
        }
    }

    public void IncreaseCurrentHealth(int amount)
    {
        currentHealth += amount;

        currentHealth = Mathf.Min(currentHealth, maxHealth);

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
        // Ajoutez d'autres fonctionnalités de mise à jour ici si nécessaire.
    }
}
