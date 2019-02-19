using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[System.Serializable]
public struct MovementLimits : ISharedComponentData
{
    public float yUpper;
    public float yLower;
    public float xUpper;
    public float xLower;
    public float zUpper;
    public float zLower;
}
public class MovementLimitsComponent : SharedComponentDataWrapper<MovementLimits> { }
