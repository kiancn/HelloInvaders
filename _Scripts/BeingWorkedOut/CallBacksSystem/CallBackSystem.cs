using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CallBackSystem : MonoBehaviour
{
    // a delegate is a reference to one or several methods
    public delegate void OnMessageRecieved();
    // name of event HAS to match delegate for Observer Pattern to work
    public event OnMessageRecieved onComplete;


    // Start is called before the first frame update
    void Start()
    {
        // I want to subscribe onComplete to WriteMessage (and WriteAnotherMessage)
        onComplete += WriteMessage;
        onComplete += WriteAnotherMessage;

        // i can then call the onComplete event, and both methods subscribed to will run.
        onComplete();

        //OnMessageRecieved test = WriteMessage;
        //test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // example 
    void WriteMessage()
    {
        Debug.Log("Message sent from WriteMesssage().");
    }
    void WriteAnotherMessage()
    {
        Debug.Log("Message sent from WriteAnotherMessager().");
    }
}
