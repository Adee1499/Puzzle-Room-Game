using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSafe : MonoBehaviour
{
    public Transform frame;
    public Transform rotationAxis;
    private float rotationSpeed = 35f;
    private IEnumerator coroutineOpen;
    private IEnumerator coroutineClose;
    public bool closed = true;
    public GameObject hand;
    public GameObject painting;
    private bool isFrameClosed = true;
    public GameObject knob;
    private bool correctCombination = false;
    private AudioSource safeDoorAudio;
    private bool playerPrefsSafe;
    void Start()
    {
        safeDoorAudio = GetComponent<AudioSource>();
        coroutineOpen = rotate();
        coroutineClose = rotateClose();
        playerPrefsSafe = (PlayerPrefs.GetInt("safeDoor") != 0);
        if (playerPrefsSafe)
        {
            transform.position = new Vector3(-3.08445f, 3.017725f, 28.66645f);
            transform.rotation = new Quaternion(-0.0000005f, -0.003720701f, -0.0000008f, 0.9999931f);
        }
    }

    void Update ()
    {
        correctCombination = knob.GetComponent<SafeKnob>().correctCombination;
        isFrameClosed = painting.GetComponent<OpenDoor>().closed;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        float angleY = frame.rotation.eulerAngles.y;

        
        if (correctCombination && !isFrameClosed && closed && hand.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(RotateHand(Vector3.back * 180, 1));
            safeDoorAudio.Play(0);
            closed = false;
            PlayerPrefs.SetInt("safeDoor", 1);
        }

        if (angleY >= 92)
        {
            StopCoroutine(coroutineOpen);
            closed = true;
        }

        if (angleY <= 1 || angleY >= 355 && angleY <= 360)
        {
            StopCoroutine(coroutineClose);
            closed = false;
        }
    }

    private IEnumerator rotate()
    {
        while (true)
        {
            transform.RotateAround(rotationAxis.position, rotationAxis.up, -rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
    private IEnumerator rotateClose()
    {
        while (true)
        {
            transform.RotateAround(rotationAxis.position, rotationAxis.up, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
    
    IEnumerator RotateHand(Vector3 byAngles, float inTime) {
        var fromAngle = hand.transform.rotation;
        // var toAngle = Quaternion.Euler(cogA.transform.eulerAngles + byAngles);
        var toAngle = fromAngle * Quaternion.Euler(byAngles);
        for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
            hand.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        hand.transform.rotation = toAngle;
        StartCoroutine(coroutineOpen);
    }
}