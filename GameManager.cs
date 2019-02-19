using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// About winning and losing: Because different win-conditions are not implemented, and you can't lose you can just die.
// this whole script looks like it does more than it does.
// More is coming.

public class GameManager : MonoBehaviour
{
    public static GameManager thisGame; // this enables transcendental reference to the static instance

    [SerializeField]
    private int score;
    public int Score { get => score; }
    [SerializeField]
    private int playerHealth;

    public bool gameIsOn = true;
    [Header("Does finishing wave Win level?")]
    public bool winConditionFinishWaves;
    [Header("Are Win-Condition object already in heirarchy?")]
    // if not, the gameobjects will be instantiated; if, they be enabled upon request
    [SerializeField]
    private bool winConditionGameObjectsPreloaded;

    [Header("Objects spawned upon win")]
    //public SceneSwitcher sceneSwitcherReference; - main purpose, many uses.
    public List<GameObject> winConditionGameObjects;

    [Header("Objects spawned upon lose")]
    //public SceneSwitcher sceneSwitcherReference;
    public List<GameObject> loseConditionGameObjects;

    [Header("Other conditions")] // yet a dream
    public bool reloadConditionDie;
    public bool reloadConditionLastDie;

    // event that other methods can subscribe to when score changes
    public event Action<int> OnScoreChange = delegate { };

    private void Awake()
    {
        if (thisGame == null) // when game is first loaded, thisGame needs instantiation.
        {
            thisGame = GetComponent<GameManager>(); // setting the static instance
            DontDestroyOnLoad(this); // ensures persistence of thisGame across scenes.
            Debug.Log("GameManager Loaded.");
        }
        else if (thisGame != this) // if another GameManager tries to load, this makes it self-destruct.
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        gameIsOn = true;

        //InstantiateWinConditionObject(winConditionGameObjects);
    }
    private void OnDisable()
    {
        //gameIsOn = false;
    }

    private void OnLevelWasLoaded(int level)
    {
        gameIsOn = true;
    }

    public void InstantiateWinConditionObject(List<GameObject> objects)
    {

        for (int i = 0; i < objects.Count; i++)
        {
            GameObject objectT = new GameObject();
            objectT = Instantiate(objects[i]);
            objects[i].SetActive(false);
            internalWinConditionObjectsList.Add(objects[i]);
        }
    }
    [SerializeField]
    private List<GameObject> internalWinConditionObjectsList;

    public void AdjustScore(int scoreAdjustment)
    {
        score += scoreAdjustment;
        OnScoreChange(score); // score will be passed in when OnScoreChange is called.
        Debug.Log("Score is now " + score);
    }

    public int AccessScore()
    {
        return score;
    }

    public void FinishedLastWave()
    {
        if (UnityEngine.Random.Range(0, 100) < 50)
        {
            Debug.Log("You won, the waves are all done! Awazing talents. Maybe YOU should be world dictator?");
        }
        else
        {
            Debug.Log("You won, the waves are all done! Awazing talents. Maybe you SHOULD be world dictator?");
        }
        PossibleWin();
    }

    private void PossibleWin()
    {
        if (winConditionFinishWaves)
        {
            gameIsOn = false;
            //if (!winConditionGameObjectsPreloaded)
            //{
            //    GameObject gameObjectT;
            //    for (int i = 0; i < winConditionGameObjects.Count; i++)
            //    {
            //        gameObjectT = winConditionGameObjects[i];
            //        Instantiate(gameObjectT);
            //    }
            //}
            //if (winConditionGameObjectsPreloaded)
            //{

            //    for (int i = 0; i < internalWinConditionObjectsList.Count; i++)
            //    {
            //        internalWinConditionObjectsList[i].SetActive(true);
            //    }
            //}
        }
        else
        {
            Debug.Log("You didn't win yet.");
        }
    }
}
