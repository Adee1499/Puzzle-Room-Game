using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        if (PlayerPrefs.GetFloat("volumeSlider") == 0)
        {
            PlayerPrefs.SetFloat("volumeSlider", 1);
        }
        slider.value = PlayerPrefs.GetFloat("volumeSlider");
    }

    public void PlayGame()
    {
        // maybe save active scene to PlayerPrefs then load that last active scene
        PlayerPrefs.SetFloat("volumeSlider", slider.value);
        SceneManager.LoadScene("Scenes/MainRoomScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    
}
