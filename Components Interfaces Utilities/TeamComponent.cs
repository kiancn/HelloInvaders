using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TeamComponent
{
    // teamnumber: 1 player team, 2 enemy team
    public int teamNumber;
    // a unique name, as of yet useless.
    public string actorName;
    // type of being actor is; ex pick-ups pull for this
    public string actorType;
}
