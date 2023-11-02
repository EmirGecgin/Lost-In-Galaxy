using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionWithPlanet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject,1f);
        }
    }
}
