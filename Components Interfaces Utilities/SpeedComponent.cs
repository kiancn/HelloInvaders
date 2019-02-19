using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

[Serializable]
public struct Speed : ISharedComponentData
{
    public float speed;
}
public class SpeedComponent : SharedComponentDataWrapper<Speed> { }