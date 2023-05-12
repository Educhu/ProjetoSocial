using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeSpawn;
    public float startTimeSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    void Update()
    {
        if(timeSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeSpawn = startTimeSpawn;

            if(startTimeSpawn > minTime)
                startTimeSpawn -= decreaseTime;
        }
        else
            timeSpawn -= Time.deltaTime;
    }
}
