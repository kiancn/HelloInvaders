using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;

public class MovePlayerSystem : MonoBehaviour
{
    public Player player;
    public PlayerInputConfiguration inputConfig;
    public MovementLimits myMoveLimits;
    public Speed speed;
    public Transform myTransform;

    private void OnEnable()
    {
        player = new Player();
        myTransform = gameObject.transform;
        //myMoveLimits = new MovementLimits
        //{
        //    //yLower = -4f,
        //    //yUpper = -2f,
        //    //xLower = -9.6f,
        //    //xUpper = 6.8f
        //};
    }

    void FixedUpdate()
    {
        float dT = Time.deltaTime;
        Vector3 curPos = transform.position;
        if (Input.GetKey(inputConfig.up) && curPos.y < myMoveLimits.yUpper)
        { curPos += new Vector3(0, speed.speed * dT, 0); }
        if (Input.GetKey(inputConfig.down) && curPos.y > myMoveLimits.yLower)
        { curPos -= new Vector3(0, speed.speed * dT, 0); }
        if (Input.GetKey(inputConfig.right) && curPos.x < myMoveLimits.xUpper)
        { curPos += new Vector3(speed.speed * dT, 0, 0); }
        if (Input.GetKey(inputConfig.left) && curPos.x > myMoveLimits.xLower)
        { curPos -= new Vector3(speed.speed * dT, 0, 0); }

        myTransform.position = curPos;

    }
}

// JOB SYSTEM BLAH
//}using Unity.Collections;
//using Unity.Entities;
//using Unity.Jobs;
//using Unity.Burst;
//using Unity.Mathematics;
//using Unity.Transforms;
//using UnityEngine;
//using UnityEngine.Jobs;

//public class MovePlayerSystem : MonoBehaviour
//{
//    //MovePlayerPosition moveJob;
//    //JobHandle moveJobHandle;

//    public Player player;
//    public PlayerInputConfiguration inputConfig;
//    //public Transform transform;
//    public Speed speed;

//    public Transform myTransform;
//    //public TransformAccess transformAccess;
//    //public NativeArray<Vector3> transformNA;


//    private void OnEnable()
//    {
//        player = new Player();

//        myTransform = gameObject.transform;

//        //transformAccess = new TransformAccess();
//        //inputConfig = GetComponent<PlayerInputConfiguration>();
//        speed = GetComponent<Speed>();

//    }

//    //private struct MovePlayerPosition : IJobParallelForTransform
//    ////private struct MovePlayerPosition : IJob
//    //{
//    //    public Player playerJ;
//    //    public PlayerInputConfiguration inputConfigJ;
//    //    public TransformAccess transformJ;
//    //    //public Transform transformJ;
//    //    public Speed speedJ;
//    //    public float dTJ;
//    //    public NativeArray<Vector3> transformNAJ;

//    //    public void Execute(int i, TransformAccess transform)
//    //    {
//    //        if (Input.GetKeyDown(inputConfigJ.up)) { transformJ.position += new Vector3(0, speedJ.speed * dTJ, 0); }
//    //        if (Input.GetKeyDown(inputConfigJ.down)) { transformJ.position -= new Vector3(0, speedJ.speed * dTJ, 0); }
//    //        if (Input.GetKeyDown(inputConfigJ.left)) { transformJ.position -= new Vector3(speedJ.speed * dTJ, 0, 0); }
//    //        if (Input.GetKeyDown(inputConfigJ.right)) { transformJ.position += new Vector3(speedJ.speed * dTJ, 0, 0); }

//    //    }
//    //}

//    void Update(/*JobHandle inputDeps*/)
//    {
//        //    float dT = Time.deltaTime;

//        //    moveJob = new MovePlayerPosition
//        //    {
//        //        playerJ = player,
//        //        inputConfigJ = inputConfig,
//        //        transformJ = transformAccess,
//        //        speedJ = speed,
//        //        dTJ = dT
//        //    };

//        //    moveJobHandle = moveJob.Schedule();


//        float dT = Time.deltaTime;
//        if (Input.GetKey(inputConfig.up)) { myTransform.position += new Vector3(0, speed.speed * dT, 0); }
//        if (Input.GetKey(inputConfig.down)) { myTransform.position -= new Vector3(0, speed.speed * dT, 0); }
//        if (Input.GetKey(inputConfig.left)) { myTransform.position -= new Vector3(speed.speed * dT, 0, 0); }
//        if (Input.GetKey(inputConfig.right)) { myTransform.position += new Vector3(speed.speed * dT, 0, 0); }

//    }
//}
