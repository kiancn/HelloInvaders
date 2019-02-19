using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// GenericShield goes on the Player Game Object
public class GenericShield : MonoBehaviour
{
    // the GO that this script targets
    public GameObject shieldGameObject;
    // if true, shield will deactivate after shieldDuration
    public bool disableOnTimer;
    // life-time of shield
    public float shieldDuration;
    // time between possible shield activations
    public float timeBetweenShieldActivation;

    // value set on enable and when shield is activated
    public float timeForNextShield;


    // components that are on shieldGameObject
    private ActorSystem shieldActorSystem;
    private HealthSystem shieldHealth;
    // key-binding setup, Scriptable Object
    public ButtonReferences buttonReferences;

    bool gameIsOn = true;

    private void Awake()
    {
        shieldActorSystem = shieldGameObject.GetComponent<ActorSystem>();
        shieldHealth = shieldGameObject.GetComponent<HealthSystem>();
    }

    private void OnEnable()
    {
        StartCoroutine(ShieldResponse());

    }

    public IEnumerator ShieldResponse()
    {
        while (gameIsOn)
        {
            if (Input.GetKeyDown(buttonReferences.activateShield))
            {
                if (Time.time >= timeForNextShield)
                {
                    timeForNextShield = Time.time + timeBetweenShieldActivation;
                    StartCoroutine(ShieldLifeTime());
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerator ShieldLifeTime()
    {
        Debug.Log("Shield is firing up.");
        shieldHealth.health.healthCurrent = shieldHealth.health.healthMax;
        shieldGameObject.SetActive(true);
        float shieldDurationT = Time.time + shieldDuration;
        bool continueChecking = true;
        while (continueChecking)
        {
            if (Time.time < shieldDurationT)
            {

            }
            if (Time.time >= shieldDurationT)
            {
                if (disableOnTimer)
                {
                    continueChecking = false;
                    shieldGameObject.SetActive(false);
                }
            }
            yield return new WaitForFixedUpdate();
        }

    }
}
