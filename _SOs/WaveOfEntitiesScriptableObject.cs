using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaveOfEntitiesScriptableObject : ScriptableObject
{
    public float timeBetweenSpawns;
    public float spaceBetweenSpawns;
    public List<GameObject> waveConstituents;
}

