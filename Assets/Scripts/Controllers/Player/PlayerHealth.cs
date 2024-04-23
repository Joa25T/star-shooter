using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;

    public float PlayersHealth => _currentHealth;

    public static bool PlayerAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void DamageTaken(Damage damage)
    {
        _currentHealth -= damage.ammount;
        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        PlayerAlive = false;
        Destroy(this.gameObject);
    }
}
