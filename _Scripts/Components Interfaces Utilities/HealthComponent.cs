using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[System.Serializable]
public struct Health : ISharedComponentData
{
    public TBool isAlive;
    public int healthMax;
    public int healthCurrent;


}
public class HealthComponent : SharedComponentDataWrapper<Health> { }


