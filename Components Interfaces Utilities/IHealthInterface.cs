using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthInterface
{
    void TakeDamage(int damageAmount);
    void Die();
}
