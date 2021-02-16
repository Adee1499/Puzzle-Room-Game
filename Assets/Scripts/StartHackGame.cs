using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartHackGame : MonoBehaviour
{
    public Camera cameraFPS;
    public GameObject player;
    private bool complete = false;
    public Material solved;
    public GameObject screen;
    public GameObject drawer;
    private bool door = false;
    private AudioSource matrixSound;
    public GameObject matrixTune;
    public bool drawerOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        matrixTune = GameObject.Find("MatrixTune");
        matrixSound = matrixTune.GetComponent<AudioSource>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(matrixTune);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        complete = (PlayerPrefs.GetInt("HackDone") != 0);
        
        if (!complete && GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && Input.GetMouseButtonDown(0))
        {
            //Sets Position
            PlayerPrefs.SetFloat ("x", player.transform.position.x);
            PlayerPrefs.SetFloat ("y", player.transform.position.y);
            PlayerPrefs.SetFloat ("z", player.transform.position.z);
            //Sets Rotation
            PlayerPrefs.SetFloat ("rotx", player.transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat ("roty", player.transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat ("rotz", player.transform.rotation.eulerAngles.z);
            
            Cursor.lockState = CursorLockMode.None;
            
            matrixSound.Play(0);
            SceneManager.LoadScene("Scenes/HackMinigameScene");
        }

        
        if (complete)
        {
            matrixSound.Stop();
            screen.GetComponent<MeshRenderer>().material = solved;
            if (drawer.transform.position.x < 5.504f)
            {
                drawer.transform.Translate(Vector3.left * (Time.deltaTime * 0.3f));
            }

            drawerOpen = true;
        }
    }
}
