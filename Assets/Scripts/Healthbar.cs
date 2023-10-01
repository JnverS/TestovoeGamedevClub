using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider _slider;
    void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    /*private void OnEnable()
    {
        GameEvents.Instance.OnPlayerHealthChanged += UpdateHealthbar;
    }
    private void OnDisable()
    {
        GameEvents.Instance.OnPlayerHealthChanged -= UpdateHealthbar;

    }*/
    // Update is called once per frame
    public void UpdateHealthbar(float currentHealth, float maxHealth)
    {
        _slider.value = currentHealth/ maxHealth;
    }
}
