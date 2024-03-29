using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    public event Action<int> OnDamageChanged;


    PlayerMove playerMove;

    [SerializeField] float timeToAttack = 4f;
    float timer;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);

    [SerializeField] int whipDamage = 25;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            EnnemyStat e = colliders[i].GetComponent<EnnemyStat>();
            if (e != null)
            {
                colliders[i].GetComponent<EnnemyStat>().TakeDamage(whipDamage);
            }

        }
    }
    public void IncreaseDamage(int amount)
    {
        whipDamage += amount;

        if (OnDamageChanged != null)
        {
            OnDamageChanged.Invoke(whipDamage);
        }
    }
}