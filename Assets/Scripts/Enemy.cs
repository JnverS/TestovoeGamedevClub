using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health, maxHealth = 100;
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private float speed;
    [SerializeField] private float attackRange;
    [SerializeField] private float detectionRange;
    [SerializeField] private int attackDamage;
    private Vector3 offset = new Vector3 (0.6f, 0, 0);
    public Rigidbody2D target;
    public Rigidbody2D rb;
    private LootSystem lootSystem;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        healthbar.UpdateHealthbar(health, maxHealth);
        lootSystem = FindObjectOfType<LootSystem>();
    }

    public void GiveTarget(Rigidbody2D targetBody)
    {
        target = targetBody;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Kill();
        }
        healthbar.UpdateHealthbar(health, maxHealth);
    }
    public void Kill()
    {
        Destroy(gameObject);
        lootSystem.GiveLoot(transform);
    }
    private void Update()
    {
        if (target == null)
        {
            transform.position = this.transform.position;
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Игрок обнаружен в диапазоне обнаружения
            if (distanceToPlayer <= attackRange)
            {
                // Игрок в диапазоне атаки, атакуем его
                AttackPlayer();
            }
            else
            {
                // Игрок в диапазоне обнаружения, но не в диапазоне атаки, двигаемся к нему
                MoveTowardsTarget();
            }
        }
        else
        {
            transform.position = this.transform.position;
        }

    }

    private void AttackPlayer()
    {
        target.GetComponent<Player>().TakeDamage(attackDamage);
        transform.position = this.transform.position - offset;

    }

    void MoveTowardsTarget()
    {
        // Направление к цели (игроку)
        Vector3 direction = (target.position - rb.position).normalized;
        // Двигаем монстра
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
