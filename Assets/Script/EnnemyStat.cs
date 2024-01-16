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
            //targetCharacter = GetComponent<Level>().AddExperience(experience_reward);
            Die();
        }
    }

    void Die()
    {
        GameObject myLevel = GameObject.Find("LevelManager");

        Debug.Log(myLevel.GetComponent<Level>());
        myLevel.GetComponent<Level>().AddExperience(experience_reward);
        Debug.Log("L'ennemi a donner l exp !");
        Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
