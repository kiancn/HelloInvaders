using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHealthInterface
{
    public Health health;

    private void OnEnable()
    {
        health.healthCurrent = health.healthMax;
        health.isAlive = true;
    }

    public void TakeDamage(int damAmount)
    {
        health.healthCurrent = health.healthCurrent - damAmount;
        if (health.healthCurrent <= 0)
        {
            health.isAlive = false;
            Die();
        }
        else
        {
            Debug.Log(name + " took " + damAmount + " damage & is now at "+ health.healthCurrent + " health.");
        }
    }

   public void Die()
    {
        Debug.Log("The bugger went home to train!");
        gameObject.SetActive(false);
    }
}
