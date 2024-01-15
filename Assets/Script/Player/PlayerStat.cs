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
        Destroy(gameObject);
    }

    void UpdateHealth()
    {
        if (OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(currentHealth);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnnemyStat>().TakeDamage(damage);
        }
    }

    void Update()
    {
        // Ajoute d'autres fonctionnalités de mise à jour ici si nécessaire.
    }
}
