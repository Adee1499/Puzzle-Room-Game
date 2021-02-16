using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismSound : MonoBehaviour
{
    private AudioSource mechanismSound;
    private bool sofaMoved = false;
    private bool tangram5 = false;
    private bool playing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        mechanismSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sofaMoved = (PlayerPrefs.GetInt("sofaMoved") != 0);
        tangram5 = (PlayerPrefs.GetInt("tangram5") != 0);

        if (sofaMoved && !tangram5 && !playing)
        {
            mechanismSound.Play(0);
            playing = true;
        }
    }
}
