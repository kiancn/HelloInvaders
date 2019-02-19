using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            EventManager.TriggerEvent("test");
        }

        if (Input.GetKeyDown("s"))
        {
            EventManager.TriggerEvent("Spawn");
        }

        if (Input.GetKeyDown("d"))
        {
            EventManager.TriggerEvent("Destroy");
        }

        if (Input.GetKeyDown("j"))
        {
            EventManager.TriggerEvent("Junk");
        }
    }
}