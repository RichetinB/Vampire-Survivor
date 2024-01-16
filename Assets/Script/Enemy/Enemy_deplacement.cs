using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_deplacement : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rgdbd2d;
    Transform playerTransform;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        playerTransform = FindObjectOfType<PlayerMove>().transform;

        if (playerTransform == null)
        {
            Debug.LogError("Le script PlayerMove n'a pas été trouvé dans la scène ou ne contient pas de Transform.");
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }
}
