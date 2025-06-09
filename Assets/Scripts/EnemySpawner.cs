using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 3;

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(Random.Range(-3f, 3f),  Random.Range(-3f, 3f));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

