using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MonitorScript : MonoBehaviour
{
    public Camera cameraFPS;
    private AudioSource memoriesAudio;
    private bool paused = false;
    public GameObject leftSpeaker;
    public GameObject rightSpeaker;
    private AudioSource lAudio;
    private AudioSource rAudio;

    // Start is called before the first frame update
    void Start()
    {
        memoriesAudio = GetComponent<AudioSource>();
        lAudio = leftSpeaker.GetComponent<AudioSource>();
        rAudio = rightSpeaker.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (!memoriesAudio.isPlaying && !paused && GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && Input.GetMouseButtonDown(0))
        {
            lAudio.Pause();
            rAudio.Pause();
            memoriesAudio.Play(0);
        }
        
        if (memoriesAudio.isPlaying && !paused && GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && Input.GetMouseButtonDown(0))
        {
            memoriesAudio.Pause();
            lAudio.UnPause();
            rAudio.UnPause();
            StartCoroutine(Wait());
        }
        
        if (!memoriesAudio.isPlaying && paused && GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && Input.GetMouseButtonDown(0))
        {
            lAudio.Pause();
            rAudio.Pause();
            memoriesAudio.UnPause();
            paused = false;
        }
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        paused = true;
    }
}
