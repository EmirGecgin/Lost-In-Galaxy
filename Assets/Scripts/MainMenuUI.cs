using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    public GameObject panel;
    public GameObject button;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void Credits()
    {
        panel.SetActive(true);
    }

    public void CreditsQuit()
    {
        panel.SetActive(false);
    }
}
