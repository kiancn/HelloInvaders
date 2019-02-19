using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAutofire : MonoBehaviour
{
    Transform player;
    Transform thisGunTransform;
    public GameObject thisGunGO;
    GenericWeapon thisGun;

    public Vector3 searchSpreadLeft;
    public Vector3 searchSpreadRight;

    public float timeForNextFire;

    public void SearchArea()
    {
        Collider[] leftSearch = Physics.OverlapBox(thisGunTransform.position + searchSpreadLeft, thisGunTransform.localScale*1.5f, Quaternion.identity);
        Collider[] rightSearch = Physics.OverlapBox(thisGunTransform.position + searchSpreadRight, thisGunTransform.localScale*1.5f, Quaternion.identity);
        if (leftSearch.Length > 0 | rightSearch.Length > 0)
        {
            thisGun.Fire();
            timeForNextFire = Time.time + thisGun.fireRate;
        }
    }

    private void OnEnable()
    {
        thisGunTransform = thisGunGO.transform;
        thisGun = thisGunGO.GetComponent<GenericWeapon>();
        timeForNextFire = Time.time + thisGun.fireRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > timeForNextFire)
        {
            SearchArea();
        }

    }
}
