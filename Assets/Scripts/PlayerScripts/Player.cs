using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health, _maxHealth = 100;
    [SerializeField] private Healthbar healthbar;

    public int Health
    {
        get 
        { 
            return _health; 
        }
        set
        {
            _health = value;
            //GameEvents.Instance.InvokePlayerHealthChanged(Health, _maxHealth);
        }
    }
    void Start()
    {
        Health = _maxHealth;
        healthbar.UpdateHealthbar(Health, _maxHealth);
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
    
}
