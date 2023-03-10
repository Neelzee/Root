using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Enemy : Actor
{
    [Header("Climate Awareness")]
    [Tooltip("Likelihood of this unit's death increasing Climate Awareness")]
    [SerializeField] protected float caIncrementChance;
    [Tooltip("How much Climate Awareness is increased if this unit is killed")]
    [SerializeField] protected float caValue;
    
    [Header("Resistance")]
    [Tooltip("Likelihood of this unit's death increasing Resistance")]
    [SerializeField] protected float resIncrementChance;
    [Tooltip("How much Resistance is increased if this unit is killed")]
    [SerializeField] protected float resValue;
    
    public override void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        if (Random.Range(0, 100) / 100f < caIncrementChance)
        {
            ClimateAwareness.Add(caValue);
        }
        
        if (Random.Range(0, 100) / 100f < resIncrementChance)
        {
            ClimateAwareness.Add(resValue);
        }
        Destroy(gameObject);
    }
}
