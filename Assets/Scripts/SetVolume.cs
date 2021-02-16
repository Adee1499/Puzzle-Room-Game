﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider slider;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MainVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("volumeSlider", sliderValue);
    }
}
