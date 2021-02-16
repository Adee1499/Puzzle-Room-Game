using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject canvas;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumeSlider");
    }

    void Update()
    {
        if (pausePanel.activeInHierarchy) canvas.SetActive(false);
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        canvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

}