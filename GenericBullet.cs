using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericBullet : MonoBehaviour, IMovePattern
{
    public float lifeTimeInSeconds;

    public Speed speed;
    public int damageAmount;

    private float timeToDisable;

    public Vector3 acceleration;
    Vector3 curPos;
    public Transform gunTransform;
    public GameObject parentGO;
    private HealthSystem ownerHealth;
    private ActorSystem ownerActorSystem;

    public int teamNumber;

    private void Awake()
    {

        //teamNumber = ownerActorSystem.teamComponent.teamNumber;
    }

    private void OnEnable()
    {
        //ownerActorSystem = GetComponentInParent<ActorSystem>();
        //teamNumber = ownerActorSystem.teamComponent.teamNumber;
        InitializeBullet();
    }

    void FixedUpdate()
    {
        float dT = Time.deltaTime;
        if (Time.time > timeToDisable)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            //Debug.Log("Bullet is trying to move!");
            Move(curPos, dT);
        }
    }

    public void InitializeBullet()
    {
        ownerHealth = GetComponentInParent<HealthSystem>();
        acceleration = new Vector3(0, speed.speed, 0);
        curPos = gunTransform.position;
        timeToDisable = Time.time + lifeTimeInSeconds;
    }

    // implementing Move methods; moves the bullet.
    public Vector3 Move(Vector3 curPosTemp, float deltaTime)
    {
        curPosTemp = transform.position;
        curPosTemp.y = curPosTemp.y + acceleration.y * deltaTime;
        //Debug.Log("Should be moving");
        transform.position = curPosTemp;
        return curPos;
    }

    // if two colliders meet
    private void OnTriggerEnter(Collider other)
    {
        Detonate(other);
    } 

    // of course, happens upon collision, but requires a rigidbody on the reciever(?)
    private void Detonate(Collider other) 
    {
        // disable this bullut GO if it hits, also does damage to hit
        if (other.GetComponent<HealthSystem>() != null)
        {
            HealthSystem healthToDestroy = other.GetComponent<HealthSystem>();

            if (other.GetComponent<ActorSystem>().teamComponent.teamNumber != teamNumber) // no friendly fire
            {
                healthToDestroy.TakeDamage(damageAmount);
                ScoreSignal(other); // send signal to GameManger
                gameObject.SetActive(false);
            }
        }
    }

    // send a signal to GameManager if hit
    private void ScoreSignal(Collider other) 
    {
        if (other.gameObject.GetComponent<ActorSystem>() != null)
        {
            if (other.gameObject.GetComponent<ActorSystem>().teamComponent.teamNumber != 1)
            {
                GameManager.thisGame.AdjustScore(damageAmount);
            }
        }
    }
}
