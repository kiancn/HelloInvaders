using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericWeapon : MonoBehaviour, IWeaponInterface
{
    public int bulletPoolSize;
    public List<GameObject> bulletPool;
    public GameObject bulletPrefab;
    public float fireRate;
    public float timeForNextBullet;
    private Vector3 proxySpawnPosition = new Vector3(0, 0, 5);

    public void Fire()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                bulletPool[i].transform.position = transform.position;
                bulletPool[i].SetActive(true);
                timeForNextBullet = Time.time + fireRate;
                break;
            }
        }
    }

    public void OutOfAmmo()
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        InitiateGun(bulletPoolSize);
    }

    public void InitiateGun(int poolSize)
    {
        GameObject tempBullet;
        tempBullet = Instantiate(bulletPrefab, proxySpawnPosition, Quaternion.identity);
        tempBullet.GetComponent<GenericBullet>().gunTransform = transform;
        tempBullet.GetComponent<GenericBullet>().parentGO = transform.parent.gameObject;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(tempBullet, proxySpawnPosition, Quaternion.identity);

            bulletPool.Add(bullet);
            //bulletPool[i].GetComponent<GenericBullet>().gunTransform = transform;
        }
        Destroy(tempBullet/*, 0.4f*/);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Time.time > timeForNextBullet)
            {
                Fire();
            }
        }
    }
}
