using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class GemPIckUpObject : MonoBehaviour
{
    public int ExpFromGem;


    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Level Gem = player.GetComponent<Level>();

            if (Gem != null)
            {
                if (gameObject.CompareTag("Coins"))
                {
                    Debug.Log("Piece");

                    Gem.AddExperience(ExpFromGem);

                    Destroy(GameObject.FindWithTag("Coins"));
                }
            }
        }
        else
        {
            Debug.LogError("ca marche pas");
        }
    }
}