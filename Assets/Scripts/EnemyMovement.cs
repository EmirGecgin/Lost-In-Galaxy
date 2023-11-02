using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform aimObject;
    public float enemyMovementSpeed;
    private void Update()
    {
        EnemyMove();
    }
    private void EnemyMove()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, aimObject.position, enemyMovementSpeed * Time.deltaTime);
    }
}
