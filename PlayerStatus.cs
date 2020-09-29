using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float Health;
    public float MaxHealth = 100.0f;
    public float HealthRegen;


    public EnergyStatus energyBar;

    void Start()
    {
        Health = MaxHealth;
        energyBar.SetMaxHealth(MaxHealth);
    }
    void Update()
    {
        if (Health <= 0)
        {
            Dead();
            energyBar.EnergyFill.color = energyBar.gradient.Evaluate(0f);
        }
        if (Health <= MaxHealth)
        {
            Regen();
            energyBar.SetHealth(Health);
        }
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    void damagePlayer(int TheDamage)
    {
        Health -= TheDamage;
        energyBar.SetHealth(Health);
    }

    void Dead()=> UnityEngine.Debug.Log("PlayerDied");

    void Regen()
    {
        HealthRegen = MaxHealth * 0.015f;
        Health += (HealthRegen) * Time.deltaTime;
    }
}
