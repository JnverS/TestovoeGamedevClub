using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    public event Action<float> OnPlayerHealthChanged;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    // Update is called once per frame
    public void InvokePlayerHealthChanged(int currentHealth)
    {
        OnPlayerHealthChanged?.Invoke(currentHealth);
    }
}
