using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    public ObjectsPool objectsPool;

    private int[] spawnOrder1 = { 3, 2, 4, 2, 3, 2 };
    private int[] spawnOrder2 = { 4, 3, 2, 4 };
    private int[] spawnOrder3 = { 3, 2, 2 };
    private float[] spawnPositions = { 2.5f, 0, -2.5f };


    private void Start()
    {
        StartCoroutine(EnemySpawner(3, Random.Range(1, 4)));
    }

    public IEnumerator EnemySpawner(float respawnTime, int order)
    {
        if (order == 1)
        {
            for (int i = 0; i < spawnOrder1.Length; i++)
            {
                var obj = objectsPool.GetPooledObject(spawnOrder1[i]);
                float spawnPos = spawnPositions[Random.Range(0, 3)];
                obj.transform.position = new Vector3(spawnPos, 1, 14);
                if (spawnOrder1[i] == 2)//Bird
                {

                    obj.transform.DOMove(new Vector3(spawnPos, 1, -15), 7.1f).SetEase(Ease.Linear).OnComplete(() => obj.SetActive(false));
                }
                if (spawnOrder1[i] == 3)//Plane
                {

                    obj.transform.DOMove(new Vector3(spawnPos, 1, -15), 8.3f).SetEase(Ease.Linear).OnComplete(() => obj.SetActive(false));
                }
                if (spawnOrder1[i] == 4)//Cloud
                {

                    obj.transform.DOMove(new Vector3(spawnPos, 1, -15), 20f).SetEase(Ease.Linear).OnComplete(() => obj.SetActive(false));
                }
                yield return new WaitForSeconds(respawnTime);
            }
            if (GameManager.instance.isGameActive)
                StartCoroutine(EnemySpawner(respawnTime, Random.Range(1, 4)));
        }
        else if (order == 2)
        {
            for (int i = 0; i < spawnOrder2.Length; i++)
            {
                var obj = objectsPool.GetPooledObject(spawnOrder2[i]);
                float spawnPos = spawnPositions[Random.Range(0, 3)];
                obj.transform.position = new Vector3(spawnPos, 1, 14);
                if (spawnOrder2[i] == 2)//Bird
                {

                    obj.transform.DOMove(new Vector3(spawnPos, 1, -15), 7.1f).SetEase(Ease.Linear).OnComplete(() => obj.SetActive(false));
                }
                if (spawnOrder2[i] == 3)//Plane
                {

                    obj.transform.DOMove(new Vector3(spawnPos, 1, -15), 8.3f).SetEase(Ease.Linear).OnComplete(() => obj.SetActive(false));
                }
                if (spawnOrder2[i] == 4)//Cloud
                {

                    obj.transform.DOMove(new Vector3(spawnPos, 1, -15), 20f).SetEase(Ease.Linear).OnComplete(() => obj.SetActive(false));
                }
                yield return new WaitForSeconds(respawnTime);
            }
            if (GameManager.instance.isGameActive)
                StartCoroutine(EnemySpawner(respawnTime, Random.Range(1, 4)));
        }
        else if (order == 3)
        {
            for (int i = 0; i < spawnOrder3.Length; i++)
            {
                var obj = objectsPool.GetPooledObject(spawnOrder3[i]);
                float spawnPos = spawnPositions[Random.Range(0, 3)];
                obj.transform.position = new Vector3(spawnPos, 1, 14);
                if (spawnOrder3[i] == 2)//Bird
                {

                    obj.transform.DOMove(new Vector3(spawnPos, 1, -15), 7.1f).SetEase(Ease.Linear).OnComplete(() => obj.SetActive(false));
                }
                if (spawnOrder3[i] == 3)//Plane
                {

                    obj.transform.DOMove(new Vector3(spawnPos, 1, -15), 8.3f).SetEase(Ease.Linear).OnComplete(() => obj.SetActive(false));
                }
                if (spawnOrder3[i] == 4)//Cloud
                {

                    obj.transform.DOMove(new Vector3(spawnPos, 1, -15), 20f).SetEase(Ease.Linear).OnComplete(() => obj.SetActive(false));
                }
                yield return new WaitForSeconds(respawnTime);
            }
            if (GameManager.instance.isGameActive)
                StartCoroutine(EnemySpawner(respawnTime, Random.Range(1, 4)));
        }
        else
        {
            if (GameManager.instance.isGameActive)
                StartCoroutine(EnemySpawner(respawnTime, Random.Range(1, 4)));
        }
    }

}
