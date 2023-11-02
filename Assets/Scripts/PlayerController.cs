using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform transformOfPlanet;
    [SerializeField] private float rotationSpeedPlayer;
    public bool isPlayerLive;
    public HealthUI healthUI;
    public TimeCounter timeCounter;
    [SerializeField] private AudioClip healthVoice;
    [SerializeField] private AudioClip deadVoice;
    private void Awake()
    {
        timeCounter = FindObjectOfType<TimeCounter>();
        healthUI = FindObjectOfType<HealthUI>();
        timeCounter.ScorePanel.SetActive(false);
    }

    private void Update()
    {
        PlayerMovement();
        if (Input.GetMouseButtonDown(0))
        {
            rotationSpeedPlayer *= -1;
            transform.localScale *= -1;
        }
    }
    private void PlayerMovement()
    {
        transform.RotateAround(transformOfPlanet.position, Vector3.forward, rotationSpeedPlayer * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            GetComponent<AudioSource>().PlayOneShot(deadVoice);
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            healthUI.collisonWithPlayer--;
            Debug.Log(healthUI.collisonWithPlayer);
            if (healthUI.collisonWithPlayer==2)
            {
                healthUI.healthIcon[2].gameObject.SetActive(false);
            }
            if (healthUI.collisonWithPlayer==1)
            {
                healthUI.healthIcon[1].gameObject.SetActive(false);
            }
            if (healthUI.collisonWithPlayer==0)
            {
                healthUI.healthIcon[0].gameObject.SetActive(false);
                timeCounter.ScorePanel.SetActive(true);
                timeCounter.timerText.gameObject.SetActive(false);
                rotationSpeedPlayer = 0;
                Debug.Log("Your are piece of shit!");
                isPlayerLive = false;
                StartCoroutine("LastDeadScene");
            }
        }

        if (col.gameObject.CompareTag("Health"))
        {
            GetComponent<AudioSource>().PlayOneShot(healthVoice);
        }
    }
    IEnumerator LastDeadScene()
    {
        yield return new WaitForSeconds(.4f);
        Time.timeScale = 0;
    }
    
    
}
