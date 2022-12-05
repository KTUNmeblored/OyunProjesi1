using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class BulletShoot : MonoBehaviour
{
    // SpawnPoint
    public Transform bulletPoint;
    // DestroyTime
    public float lifetime = 3;

    public void Shoot(GameObject bullet)
    {
        //Spawn New Object
        GameObject obj = Instantiate(bullet, bulletPoint.position, Quaternion.identity);
        Destroy(obj, lifetime);
    }

}
