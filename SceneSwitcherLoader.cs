using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcherLoader : MonoBehaviour
{
    public bool runCheck;

    [Header("Object spawned upon win")]
    //public SceneSwitcher sceneSwitcherReference; - main purpose, many uses.
    public GameObject sceneSwitcherObject;


    //[Header("Objects spawned upon lose")]
    ////public SceneSwitcher sceneSwitcherReference;
    //public List<GameObject> loseConditionGameObjects;

    private void OnEnable()
    {
        sceneSwitcherObject.SetActive(false);
        StartCoroutine(CheckForGameEnd());
        //runCheck = true;
    }
    public IEnumerator CheckForGameEnd()
    {
        yield return new WaitForSecondsRealtime(5);
        while (runCheck)
        {
            if (GameManager.thisGame == null)
            {
                yield return new WaitForSecondsRealtime(5);
            }
            if (GameManager.thisGame.gameIsOn)
            {
                yield return new WaitForSecondsRealtime(5);
            }
            if (!GameManager.thisGame.gameIsOn)
            {
                runCheck = false;
            }
        }
        if (!runCheck)
        {
            SetSwitcherActive();
        }
        yield return new WaitForFixedUpdate();
    }

    public void SetSwitcherActive()
    {
        sceneSwitcherObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        TurnOfCheckOnClick();
    }

    public void TurnOfCheckOnClick()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            runCheck = false;
        }
    }
}
