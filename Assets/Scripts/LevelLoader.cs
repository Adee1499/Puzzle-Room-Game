﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    
    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Scenes/MainRoomScene");

        loadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01((operation.progress / 0.9f));

            slider.value = progress;

            progressText.text = Mathf.Round(progress * 100f) + "%";
            
            yield return null;
        }
    }
}
