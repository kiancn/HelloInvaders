using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.Jobs;

public struct TransformC : ISharedComponentData
{
    public TransformAccess transformAccess;
}
public class TransformCComponent : SharedComponentDataWrapper<TransformC> { }

