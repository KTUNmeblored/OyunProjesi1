using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] public ObjectsPool objectPool = null;

    // SpawnPoint
    public Transform bulletPoint;
    public Button firee;

    public void Shoot(int objectType)
    {
        //Spawn New Object
        var obj = objectPool.GetPooledObject(objectType);
        obj.transform.position = bulletPoint.position;
        StartCoroutine(Disableobj(obj));
        StartCoroutine(DisableButton(firee));
    }

    // Object Disable
    IEnumerator Disableobj(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        obj.SetActive(false);
    }
    // Fire cooldown
    IEnumerator DisableButton(Button firee)
    {
        firee.interactable = false;
        yield return new WaitForSeconds(0.5f);
        firee.interactable = true;
    }
}
