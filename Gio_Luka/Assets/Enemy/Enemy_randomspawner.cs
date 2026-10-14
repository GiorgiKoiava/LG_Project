using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_randomspawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPositions;

    IEnumerator Start()
    {
        while (true)
        {
            int i = Random.Range(0, spawnPositions.Length);
            Instantiate(enemyPrefab, spawnPositions[i].position, Quaternion.identity);

            yield return new WaitForSeconds(4f);
        }
    }
}
