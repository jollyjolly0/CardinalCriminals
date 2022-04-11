using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public float lastSpawn;

    public float xRange;
    public float yRange;

    private void Awake()
    {
        //lastSpawn = Time.time;
    }
    private void Update()
    {
        if (Time.time - lastSpawn > spawnInterval)
        {
            SpawnEnemy(spawnPostion());
            lastSpawn = Time.time;
        }
    }

    Vector3 spawnPostion()
    {
        Vector3 center = transform.position;
        float xPos = Random.Range(center.x - xRange, center.x + xRange);
        float yPos = Random.Range(center.y - yRange, center.y + yRange);
        return new Vector3(xPos, yPos);
    }
    void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
