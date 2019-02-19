using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Text mText;
    //public TextMeshPro mText;
    private int theScore;

    public bool trackScore;


    private void Awake()
    {
        StartCoroutine(LocateGameManager());
    }

    private IEnumerator LocateGameManager()
    {
        while (GameManager.thisGame == null)
        {
            Debug.Log("Waiting for GameManager to exist");
            yield return new WaitForSecondsRealtime(0.05f);
        }
        Debug.Log("GameManager found and score initatied at " + theScore);
        theScore = GameManager.thisGame.Score;
        trackScore = true;
    }

    private void OnEnable()
    {
        mText = GetComponent<Text>();
        StartCoroutine(UpdateScore(theScore));
    }

    public IEnumerator UpdateScore(int theScoreT)
    {
        while (!trackScore)
        {
            yield return new WaitForSecondsRealtime(0.3f);
        }
        while (trackScore)
        {
            
                theScore = GameManager.thisGame.AccessScore();
                mText.text = "" + theScore + "";
            
            if (theScore == 0)
            {
                mText.text = "Hello Invader";
            }
            yield return new WaitForSecondsRealtime(0.3f);
        } 
    }

    private void OnDisable()
    {
        trackScore = false;
    }
}
