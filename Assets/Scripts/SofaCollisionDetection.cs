using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaCollisionDetection : MonoBehaviour
{
    public bool solved = false;
    public AudioSource sound;
    private bool sofaMoved = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // sound = GetComponent<AudioSource>();
        sofaMoved = (PlayerPrefs.GetInt("sofaMoved") != 0);
        if (sofaMoved)
        {
            transform.position = new Vector3(3.549647f, 0.08539f, 27.5126f);
            transform.rotation = new Quaternion(0f, 0.7108111f, 0f, 0.7033823f);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "interactable" && !sofaMoved)
        {
            solved = true;
            sound.Play(0);
            PlayerPrefs.SetInt("sofaMoved", 1);
        }
    }
}
