using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;
    public UnityEvent OnHealthEnd;
    public UnityEventHealth OnHealthValueChanged;

    [SerializeField, Min(0)] private float _maxHealth;
    private float _currentHealth;

    void Awake()
    {
        OnHealthEnd ??= new UnityEvent();
        OnHealthValueChanged ??= new UnityEventHealth();
        _currentHealth = _maxHealth;
    }

    public float Hit(float damage)
    {
        if (damage <= 0)
            return 0;

        float res = Mathf.Max(damage, _currentHealth);
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        OnHealthValueChanged.Invoke(new HealthEventArgs()
        {
            CurrentHealth = _currentHealth,
            MaxHealth = _maxHealth
        });

        if (_currentHealth <= 0)
            OnHealthEnd.Invoke();

        return res;
    }

    public float AddHealth(float health)
    {
        if (health <= 0)
            return 0;

        float res = Mathf.Min(health, MaxHealth - _currentHealth);
        _currentHealth = Mathf.Clamp(_currentHealth + health, 0, _maxHealth);
        OnHealthValueChanged.Invoke(new HealthEventArgs()
        {
            CurrentHealth = _currentHealth,
            MaxHealth = _maxHealth
        });
        return res;
    }
}
