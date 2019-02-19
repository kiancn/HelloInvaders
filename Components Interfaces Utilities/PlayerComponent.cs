using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

[System.Serializable]
public struct Player : ISharedComponentData
{
    public int id;
    public int name;
}

public class PlayerComponent : SharedComponentDataWrapper<Player> { } 
