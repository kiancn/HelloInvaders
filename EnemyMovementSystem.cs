using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class EnemyMovementSystem : MonoBehaviour, IMovePattern
{
    public Speed speed;
    public MovementLimits movementLimits;
    //public MoveDuration moveDuration;
    private Vector3 curPos;
    public MovementStateEnum moveState;

    [HideInInspector]
    public Vector3 downDestination;
    [HideInInspector]
    public Vector3 upDestination;

    public Vector3 elevationStep;

    //public NativeArray<int> nummbers;

    private void OnEnable()
    {
        curPos = transform.position;
        moveState = MovementStateEnum.goingLeft;
    }


    private void FixedUpdate()
    {
        curPos = transform.position;
        Move(curPos, Time.deltaTime);
        transform.position = curPos;
        ChangeMoveStateAtRandom();

    }

    public Vector3 Move(Vector3 position, float dT)
    {
        dT = Time.deltaTime;

        if (moveState == MovementStateEnum.goingLeft)
        {
            if (curPos.x > movementLimits.xLower)
            {
                curPos -= new Vector3(speed.speed * dT, 0, 0);
            }
            else
            {
                if (curPos.y < movementLimits.yUpper)
                {
                    moveState = MovementStateEnum.goingUp;
                    upDestination = curPos + elevationStep;
                }
                else if (curPos.y > movementLimits.yLower)
                {
                    moveState = MovementStateEnum.goingDown;
                    downDestination = curPos + elevationStep;
                }
            }
        }

        if (moveState == MovementStateEnum.goingDown)
        {
            if (curPos.y > movementLimits.yLower && curPos.y < downDestination.y)
            {
                curPos -= new Vector3(0, speed.speed * dT, 0);
            }
            else
            {
                moveState = MovementStateEnum.goingRight;
            }
        }

        if (moveState == MovementStateEnum.goingRight)
        {
            if (curPos.x < movementLimits.xUpper)
            {
                curPos += new Vector3(speed.speed * dT, 0, 0);
            }
            else
            {
                if (curPos.y >= movementLimits.yLower && curPos.x < movementLimits.xLower)
                {
                    moveState = MovementStateEnum.goingDown;
                }
                else
                {
                    moveState = MovementStateEnum.goingUp;
                    upDestination = curPos + elevationStep;
                }
            }
        }

        if (moveState == MovementStateEnum.goingUp)
        {
            if (curPos.y < movementLimits.yUpper && curPos.y < upDestination.y)
            {
                curPos += new Vector3(0, speed.speed * dT, 0);
            }
            else
            {
                if (curPos.x > movementLimits.xUpper)
                {
                    moveState = MovementStateEnum.goingLeft;
                }
                else
                {
                    moveState = MovementStateEnum.goingRight;
                }
            }
        }
        return curPos;
    }

    public void ChangeMoveStateAtRandom()
    {
       int randInt = Random.Range(0, 5000);

        if (randInt <= 20)
        {
            if (randInt > 0 && randInt <= 5)
            {
                moveState = MovementStateEnum.goingDown;
            }
            if (randInt > 5 && randInt <= 10)
            {
                moveState = MovementStateEnum.goingUp;
            }
            if (randInt > 10 && randInt <= 15)
            {
                moveState = MovementStateEnum.goingLeft;
            }
            if (randInt > 15 && randInt <= 20)
            {
                moveState = MovementStateEnum.goingRight;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (moveState == MovementStateEnum.goingLeft) moveState = MovementStateEnum.goingRight;
        if (moveState == MovementStateEnum.goingRight) moveState = MovementStateEnum.goingLeft;
        if (moveState == MovementStateEnum.goingUp) moveState = MovementStateEnum.goingDown;
        if (moveState == MovementStateEnum.goingDown) moveState = MovementStateEnum.goingUp;
    }
}



[System.Serializable]
public struct MoveDuration
{
    public float moveDuration;
}
