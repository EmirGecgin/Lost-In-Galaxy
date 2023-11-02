using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObjectMovement : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private float objectSpeed;
    
    private void Update()
    {
        HealthObjectMove();
    }

    private void HealthObjectMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObject.position, objectSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Planet"))
        {
            Destroy(gameObject,1f);
        }
    }
}
