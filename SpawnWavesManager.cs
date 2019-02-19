using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OH! The annotations that this script will contain eventually. But none now.
/// Spawns both 'enemy waves' and 'hero waves'; importantly decide if signalOnLastWave or not ;)
/// </summary>

public class SpawnWavesManager : MonoBehaviour
{
    // evaluates to false if all waves have spawned
    private bool spawnMoreWaves;
    // if true a finished signal will be sent to gamemanager, possibly releasing a last round victory
    [Header("Set false for Hero Waves (default)")]
    public bool signalOnLastWave;

    public List<WaveOfEntitiesScriptableObject> waves;
    [SerializeField]
    private int numberOfWaves;
    public MovementLimits spawnPlacementLimits;

    [SerializeField]
    private Vector3 offSet = Vector3.zero;
    private Vector3 Offset
    {
        get
        {
            return new Vector3(
                (float)Random.Range(spawnPlacementLimits.xLower, spawnPlacementLimits.xUpper),
                (float)Random.Range(spawnPlacementLimits.yLower, spawnPlacementLimits.yUpper),
                0);
        }
    }

    private List<GameObject> currentWaveConstituentsList;
    private int lastWaveCount = 0;

    private void Awake()
    {
        numberOfWaves = waves.Count;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        spawnMoreWaves = true;
        StartCoroutine(UpdateManager());
    }



    public IEnumerator UpdateManager()
    {
        while (spawnMoreWaves)
        {
            for (int i = lastWaveCount; i < lastWaveCount + 1; i++)
            {
                currentWaveConstituentsList = new List<GameObject>();

                for (int j = 0; j < waves[i].waveConstituents.Count; j++)
                {
                    GameObject enemy = new GameObject();
                    enemy = Instantiate(waves[i].waveConstituents[j], Offset, Quaternion.identity);
                    currentWaveConstituentsList.Add(enemy);
                    yield return new WaitForSeconds(waves[i].timeBetweenSpawns);
                }
            }
            spawnMoreWaves = false;
            lastWaveCount += 1;
        }
        StartCoroutine(CheckingIfNextWaveShouldSpawn());
    }

    public IEnumerator CheckingIfNextWaveShouldSpawn()
    {
        bool allDead = false;
        while (!spawnMoreWaves)
        {
            yield return new WaitForSeconds(1);

            int curWaveListCount = currentWaveConstituentsList.Count;
            int curWaveListInactiveCount = 0;

            for (int i = 0; i < curWaveListCount; i++)
            {
                if (!currentWaveConstituentsList[i].activeSelf)
                {
                    curWaveListInactiveCount += 1;
                }

                if(curWaveListInactiveCount >= curWaveListCount)
                {
                    allDead = true;
                }
            }
            if (allDead) // set up like this a new wave spawns when the last one is downed
            {
                if (lastWaveCount >= waves.Count)
                {
                    if (signalOnLastWave)
                    {
                        GameManager.thisGame.FinishedLastWave(); // sends a signal to GameManager that all waves have been beat.
                        Debug.Log("You beat all the waves!");
                        spawnMoreWaves = false;
                        //yield return null;
                    }
                }
                else
                {
                    spawnMoreWaves = true;
                    StartCoroutine(UpdateManager());
                }
            }
        }
    }

    //public void SpawnWave(WaveOfEntitiesScriptableObject wave)
    //{
    //    wave.waveConstituents   
    //}
}
