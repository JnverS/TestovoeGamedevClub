using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health, _maxHealth = 100;
    public int Health
    {
        get 
        { 
            return _health; 
        }
        set
        {
            _health = value;
            GameEvents.Instance.InvokePlayerHealthChanged(Health);
        }
    }
    void Start()
    {
        Health = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (_health < 0)
        {
            DeathPlayer();
        }
    }

    private void DeathPlayer()
    {
        //тут игрок будет умирать
    }
}
