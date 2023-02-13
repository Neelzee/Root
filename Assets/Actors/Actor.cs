using System;
using UnityEngine;

/// <summary>
/// Base class for any actor in the game. Contains variables for health and methods for taking damage and dying.
///
/// <para>Author: Kaspar Moberg</para>
/// </summary>
public abstract class Actor : MonoBehaviour
{
    protected int CurrentHealth;
    protected int MaxHealth;

    public abstract void TakeDamage(int damage);
    
    public abstract void Die();

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    private void Start()
    {
        OnStart();
    }

    public virtual void OnStart()
    {
        
    }
}
