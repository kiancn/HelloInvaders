using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ObjectSpawnerScript : MonoBehaviour
    {       
        public int TotalAllowedObjects = 1; // ikke implementeret, gør ingenting, nada 
        public GameObject objectToSpawn;

        int CurrentCompanions;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                //if (CurrentCompanions < TotalAllowedCompanions)
                //{
                    //Spawn our AI using the Emerald Object Pool system
                    GameObject DogBitesMan = EmeraldObjectPool.Spawn(objectToSpawn, transform.position, Quaternion.identity);

                    //Set an event on the created AI to remove the AI on death
                    //SpawnedAI.GetComponent<Emerald_AI>().DeathEvent.AddListener(() => { RemoveAI(); });

                    //Add the spawned AI to the total amount of currently spawn AI
                //    CurrentCompanions++;
                //}
            }
        }
    }
