using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthUI : MonoBehaviour
{
    public int collisonWithPlayer=1;
    public List<GameObject> healthIcon;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Health"))
        {
            
            collisonWithPlayer++;
            print(collisonWithPlayer);
            if (collisonWithPlayer == 2)
            {
                healthIcon[1].SetActive(true);
            }
            if (collisonWithPlayer == 3)
            {
                healthIcon[2].SetActive(true);
            }
            if (collisonWithPlayer >= 3)
            {
                collisonWithPlayer = 3;
            }
            
        }
    }
}
