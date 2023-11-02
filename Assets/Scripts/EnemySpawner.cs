using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private Transform minSpawn, maxSpawn;
    [SerializeField] private GameObject enemy;
    public float spawnTime=2f;
    private float _endTime;

    private void Start()
    {
        _endTime = spawnTime;
    }

    private void Update()
    {
        _endTime -= Time.deltaTime;
        if (_endTime <= 0)
        {
            Instantiate(enemy, SelectSpawnPoint(), Quaternion.identity);
            _endTime=spawnTime;
        }
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;
        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = minSpawn.position.y;
            }  
        }
        return spawnPoint;
    }
}
