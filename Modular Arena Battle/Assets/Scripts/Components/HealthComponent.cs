using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int currentHealth;
    public IDeathHandler deathHandler;

    public void Awake()
    {
        currentHealth = maxHealth;
        deathHandler = GetComponent<IDeathHandler>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (deathHandler != null)
        {
            deathHandler.HandleDeath();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
