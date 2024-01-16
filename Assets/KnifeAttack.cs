using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 100;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - (Vector2)transform.position;

        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);

        if (!IsInCameraView())
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnnemyStat>().TakeDamage(damage);

        }
    }

    bool IsInCameraView()
    {
        return GetComponent<Renderer>().isVisible;
    }
}
