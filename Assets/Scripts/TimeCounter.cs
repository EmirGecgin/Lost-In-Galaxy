using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI timerText,currentScoreText,bestScoreText;
    public int _time;
    public PlayerController playerController;
    public EnemySpawner enemySpawner;
    public EnemyMovement enemyMovement;
    public GameObject ScorePanel;
    
    private void Start()
    {
        Debug.Log(Time.timeScale);
        ScorePanel.SetActive(false);
        enemySpawner.spawnTime = 1f;
        enemyMovement.enemyMovementSpeed = 2.5f;
        playerController.isPlayerLive = true;
        _time = 0;
        StartCoroutine("TimeController");
        InvokeRepeating("EnemyUpdate",15,12);
    }

    private void Update()
    {
        currentScoreText.text = "YOUR TIME"+"\n" + timerText.text;
        if (_time > PlayerPrefs.GetInt("HighTime"))
        {
            PlayerPrefs.SetInt("HighTime",_time);
            
        }
        bestScoreText.text = "YOUR BEST TIME"+ "\n" + $"{PlayerPrefs.GetInt("HighTime")/60:00}:{PlayerPrefs.GetInt("HighTime")%60:00}";
    }

    IEnumerator TimeController()
    {
        while (playerController.isPlayerLive)
        {
            timerText.text = $"{_time/60:00}:{_time%60:00}";
            yield return new WaitForSeconds(1f);
            _time++;
        }
    }

    private void EnemyUpdate()
    {
        enemySpawner.spawnTime -= 0.1f;
        if (enemySpawner.spawnTime <= 0.4f)
        {
            enemySpawner.spawnTime = 0.4f;
        }
        enemyMovement.enemyMovementSpeed += 0.25f;

    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
