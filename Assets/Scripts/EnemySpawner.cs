using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float[] weightsArray;    //keeps track of how much each unit is worth
    public float spawnInterval;
    public float lastSpawn;

    public float rampInterval;
    public float rampRatio;
    public float rampScale;
    private float lastRamp;

    public float northYVal;
    public float northXMin;
    public float northXMax;

    public float southYVal;
    public float southXMin;
    public float southXMax;

    public float westXVal;
    public float westYMin;
    public float westYMax;

    public float eastXVal;
    public float eastYMin;
    public float eastYMax;

    public float timeToIncreaseLevel;
    private float lastLevelIncrease;
    private int currentLevel =1;
    private int maxLevel;

    public float currentWeight = 5f;
    private float remainder = 0f;

    private void Awake()
    {
        maxLevel = enemyPrefabs.Length;
    }
    private void Update()
    {
        if (Time.time > spawnInterval + lastSpawn)
        {
            SpawnGroup(currentWeight, currentLevel);
            lastSpawn = Time.time;
        }
        if(Time.time>rampInterval+lastRamp)
        {
            currentWeight += rampScale;
            lastRamp = Time.time;
        }
        if(currentLevel <maxLevel && Time.time> timeToIncreaseLevel+lastLevelIncrease)
        {
            currentLevel++;
            lastLevelIncrease = Time.time;
        }
    }

    Vector3 spawnPostion()
    {
        int zone = Random.Range(0, 4);
        float xPos = 0;
        float yPos = 0;
        switch (zone)
        {
            case 0:
                xPos = Random.Range(northXMin, northXMax);
                yPos = northYVal;
                return new Vector3(xPos, yPos);
            case 1:
                xPos = eastXVal;
                yPos = Random.Range(eastYMin, eastYMax);
                return new Vector3(xPos, yPos);
            case 2:
                xPos = Random.Range(southXMin, southXMax);
                yPos = southYVal;
                return new Vector3(xPos, yPos);
            default:
                xPos = westXVal;
                yPos = Random.Range(westYMin, westYMax);
                return new Vector3(xPos, yPos);

        }
    }

    void SpawnGroup(float weight, int strongest)
    {
        weight = weight + remainder;
        while(weight > 0)
        {
            int unit = Random.Range(0, strongest);
            float unitWeight = weightsArray[unit];
            weight -= unitWeight;
            SpawnEnemy(spawnPostion(), unit);
        }
        remainder = weight;
    }
    void SpawnEnemy(Vector3 position, int index = 0)
    {
        Instantiate(enemyPrefabs[index], position, Quaternion.identity);
    }
}
