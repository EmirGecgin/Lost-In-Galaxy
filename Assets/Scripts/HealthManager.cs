 using System;
 using System.Collections;
using System.Collections.Generic;

 using UnityEngine;
    using Random = UnityEngine.Random;
    public class HealthManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    [SerializeField] private GameObject healthObject;
    private float _endTime;
    [SerializeField] private float spawnTime=2;
    [SerializeField] private Transform minSpawn, maxSpawn;
    private void Start()
    {
        _endTime = spawnTime;
    }
    void Update()
    {
        _endTime -= Time.deltaTime;
        if (_endTime <= 0)
        {
            int selectedNumber = Random.Range(1,11);
            if (selectedNumber == 3)
            {
                HealthObjectSpawn();
            }
            _endTime = spawnTime;
        }
    }
    private void HealthObjectSpawn()
    {
        
        Instantiate(healthObject, enemySpawner.SelectSpawnPoint(), Quaternion.identity);
    }
}
