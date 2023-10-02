using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Healthbar healthbar;

    private int _health, _maxHealth = 100;
    Rigidbody2D rb;
    public int Health
    {
        get 
        { 
            return _health; 
        }
        set
        {
            _health = value;
        }
    }
    void Start()
    {
        Health = _maxHealth;
        healthbar.UpdateHealthbar(Health, _maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (_health < 0)
        {
            DeathPlayer();
        }
        healthbar.UpdateHealthbar(Health, _maxHealth);
    }

    private void DeathPlayer()
    {
        gameObject.SetActive(false);
    }

    public void Punch(Vector3 direction, float power)
    {
        rb.AddForce(direction * power);
    }
}
