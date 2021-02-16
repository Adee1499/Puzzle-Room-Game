using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 2f;

    public Vector3 velocity;
    public float gravity = -9.81f;
    public Camera cameraFPS;

    public GameObject pauseMenu;
    private bool cameraActive = true;

    public GameObject body;
    
    private void Start()
    {
        if (PlayerPrefs.GetFloat("x") != 0 && PlayerPrefs.GetFloat("y") != 0 && PlayerPrefs.GetFloat("z") != 0) Load();
    }

    // Update is called once per frame
    void Update()
    {
        cameraActive = (cameraFPS.targetDisplay == 0);

        if (!cameraActive)
        {
            body.GetComponent<MeshRenderer>().enabled = false;
            body.GetComponent<CapsuleCollider>().enabled = false;
        }
        
        if (cameraActive && !pauseMenu.activeInHierarchy)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * (speed * Time.deltaTime));

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

        // change to escape in production
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        if (PlayerPrefs.GetInt("hackDone") == 1 && PlayerPrefs.GetInt("respawned") != 1)
        {
            transform.position = new Vector3(
                6.511766f,
                -4.667583f,
                30.68822f);
            PlayerPrefs.SetInt("respawned", 1);
        }

    }

    void Load()
    {
        //Gets and Changes Position
        transform.position = new Vector3(
            PlayerPrefs.GetFloat("x"),
            PlayerPrefs.GetFloat("y"),
            PlayerPrefs.GetFloat("z"));

        //Gets and Changes Rotation
        transform.rotation = Quaternion.Euler(
            PlayerPrefs.GetFloat("rotx"),
            PlayerPrefs.GetFloat("roty"),
            PlayerPrefs.GetFloat("rotz"));

    }
}