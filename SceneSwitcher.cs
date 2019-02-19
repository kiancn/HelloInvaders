using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//// SceneSwitcher has two modes; looking for other scene by 
//// string name, or by build index:
//// if useSceneName is false index for next scene will be accessed.

public class SceneSwitcher : MonoBehaviour
{
    [Header("Load scene by build index? = probs atm")]
    //Set false to enable loading scene by name.
    public bool loadSceneByBuildIndex;

    [Header("Set true to load in to next index or Primary string")]
    // Set false to a) load previous scene in build index or b) use sceneToLoadPreviousString
    public bool loadSceneNext;    

    [SerializeField]
    Scene thisScene;    // must match the string name of the intended scene.

    public string sceneToLoadPrimaryString;    
    public string sceneToLoadSecondaryString;

    int thisSceneIndexInt;
    int sceneToLoadNextIndexInt;
    int sceneToLoadPreviousIndexInt;

    #region Implementation
    private void Awake()
    {
        GetSceneReference();
    }

    private void OnEnable()
    {
        GetSceneReference();
    }

    public void OnMouseDown()
    {
        LoadScene();
    }

    private void OnCollisionEnter(Collision collision)
    {
        LoadScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadScene();
    }
    #endregion


    private void GetSceneReference()
    {
        if (thisScene == null)
        {
            thisScene = SceneManager.GetActiveScene(); // something not working here at all... indexes don't register
            thisSceneIndexInt = thisScene.buildIndex;
            //Debug.Log("thisSceneIndex is now " + thisSceneIndexInt);
            sceneToLoadNextIndexInt = thisSceneIndexInt + 1;
            //Debug.Log("thisSceneIndex is now " + sceneToLoadNextIndexInt);
            sceneToLoadPreviousIndexInt = thisSceneIndexInt - 1;
            //Debug.Log("sceneToLoadBackwardIndex  is now " + sceneToLoadPreviousIndexInt);
        }
        else
        {
            //Debug.Log("Build index of thisScene " + thisScene.buildIndex);
            //Debug.Log("thisSceneIndex is now " + thisSceneIndexInt);
            //Debug.Log("thisSceneIndex is now " + sceneToLoadNextIndexInt);
            //Debug.Log("sceneToLoadBackwardIndex  is now " + sceneToLoadPreviousIndexInt);
        }
    }

    public void LoadScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        if (loadSceneNext) { LoadScene(loadSceneByBuildIndex, sceneToLoadPrimaryString, currentIndex+1); }
                        else { LoadScene(loadSceneByBuildIndex, sceneToLoadSecondaryString, currentIndex-1); }

        //if (loadSceneNext) { LoadScene(loadSceneByBuildIndex, sceneToLoadPrimaryString, sceneToLoadNextIndexInt); }
        //                else { LoadScene(loadSceneByBuildIndex, sceneToLoadSecondaryString, sceneToLoadPreviousIndexInt); }
    }

    public void LoadScene(bool useSceneIndexLocal, string sceneName, int sceneIndex)
    {
        if (useSceneIndexLocal)
        {
            SceneManager.LoadScene(sceneIndex);
            Debug.Log("Scene #" + sceneIndex + " is being loaded.");
        }
        else
        {
            SceneManager.LoadScene(sceneName);  // NB this LoadScene is from SceneManager
            Debug.Log("Scene named " + sceneName + " is being loaded.");
        }
    }
}
