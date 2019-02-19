using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
    [System.Serializable]

public struct PlayerInputConfiguration : ISharedComponentData
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
}
    [System.Serializable]
public class PlayerInputConfigurationComponent : SharedComponentDataWrapper<PlayerInputConfiguration> { }
