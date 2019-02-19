using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script tracks the healthsystem of the GameObject it is a component on.
/// At the outset it simply set up to communicate with the health bar;
/// but any method  
/// </summary>

public class HealthTracker : MonoBehaviour
{
    public HealthSystem healthSystemTracked;

    private bool persistTracking; // used to determine if coroutines continue running. not the best solution; I should be able to connect to GameManager.. but no workie.

    int latestHealthMeasure; // temporary value, storing latest health measurement
    [SerializeField]
    float currentHealthPercent; // normalized number, sent to event for Health Bar Updates

    // learning notes; this event takes a float; only methods with a float parameter
    //|| the empty delegate is declared to avoid an exception-call if we forgot to register it
    public event Action<float> OnHealthPercentChanged = delegate { };

    private void Awake()
    {   // get health component   
        GetHealthSystem();
    }

    private void OnEnable()
    {
        persistTracking = true;       
        GetHealthSystem(); // check if health component is there again

        latestHealthMeasure = healthSystemTracked.health.healthMax; // initializing var, to avoid load errors.
        currentHealthPercent = 1f;

        StartCoroutine(CheckHealth(healthSystemTracked));
    }

    private void OnDisable()
    {
        persistTracking = false;
    }

    public IEnumerator CheckHealth(HealthSystem healthSystem)
    {
        //latestHealthMeasure = healthSystem.health.healthMax;
        //currentHealthPercent = (float)latestHealthMeasure / (float)healthSystem.health.healthMax;

        while (persistTracking)
        {
            Debug.Log("Health Percent is being updated.");

            latestHealthMeasure = healthSystem.health.healthCurrent;
            currentHealthPercent = latestHealthMeasure / (float)healthSystem.health.healthMax;
            OnHealthPercentChanged(currentHealthPercent); // calling the declared event

            yield return new WaitForSecondsRealtime(0.28f);
        }
    }

    private void GetHealthSystem()
    {
        if (healthSystemTracked == null)
        {
            healthSystemTracked = GetComponent<HealthSystem>();
        }
    }
}
