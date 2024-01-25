using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnnemyStat : MonoBehaviour
{
    Character targetCharacter;
    [SerializeField] int experience_reward = 400;

    public int maxHealth = 50;
    public int currentHealth;
    public GameObject spawnPrefab;
    public int damage = 10;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 1)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Level playerLevel = player.GetComponent<Level>();

            if (playerLevel != null)
            {
                playerLevel.AddExperience(experience_reward);

                Instantiate(spawnPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Le script Level n'a pas été trouvé sur le joueur.");
            }
        }
        else
        {
            Debug.LogError("Le joueur n'a pas été trouvé dans la scène.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStat>().TakeDamage(damage); 
        }
   }

    void Update()
    {
        // Ajoute d'autres fonctionnalités de mise à jour ici si nécessaire.
    }
}
