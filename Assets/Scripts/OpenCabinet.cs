using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OpenCabinet : MonoBehaviour
{
    public GameObject LHandle;
    public GameObject RHandle;
    public GameObject LDoor;
    public GameObject RDoor;
    public Camera cameraFPS;

    private IEnumerator coroutineOpenLeft;
    private IEnumerator coroutineOpenRight;
    
    public Transform rotationAxisLeft;
    public Transform rotationAxisRight;
    private float rotationSpeed = 50f;

    private bool lOpen = false;
    private bool rOpen = false;

    public GameObject cogA;
    private bool complete = false;
    public AudioSource cabinetAudio;
    public AudioSource cabinetDoorSound;
    private bool audioPlayed = false;
    private bool cabinetOpen;
    
    
    // Start is called before the first frame update
    void Start()
    {
        coroutineOpenLeft = rotateLeft();
        coroutineOpenRight = rotateRight();
        cabinetOpen = (PlayerPrefs.GetInt("cabinetOpen") != 0);
        if (cabinetOpen)
        {
            transform.position = new Vector3(15.76675f, -0.1200019f, 21.65f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // get complete from cog A
        complete = cogA.GetComponent<CogRotate>().isComplete;
        
        float leftAngle = LDoor.transform.rotation.eulerAngles.y;
        float rightAngle = RDoor.transform.rotation.eulerAngles.y;
        
        // Debug.Log(rightAngle);
        
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (!lOpen && LHandle.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && Input.GetMouseButtonDown(0))
        {
            // Debug.Log("LEFT HANDLE");
            // LDoor.transform.Rotate( new Vector3(0, (LDoor.transform.rotation.y) + 160, 0), Space.Self );
            StartCoroutine(coroutineOpenLeft);
            cabinetDoorSound.Play(0);
            PlayerPrefs.SetInt("cabinetDoorOpen", 1);
        }
        
        if (leftAngle >= 250)
        {
            StopCoroutine(coroutineOpenLeft);
            lOpen = true;
        }
        
        if (!rOpen && RHandle.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && Input.GetMouseButtonDown(0))
        {
            // Debug.Log("RIGHT HANDLE");
            // RDoor.transform.Rotate( new Vector3(0, (RDoor.transform.rotation.y) - 160, 0), Space.Self );
            StartCoroutine(coroutineOpenRight);
            cabinetDoorSound.Play(0);
            PlayerPrefs.SetInt("cabinetDoorOpen", 1);
        }
        
        if (rightAngle <= 290 && rightAngle >= 280)
        {
            StopCoroutine(coroutineOpenRight);
            rOpen = true;
        }
        

        // move cabinet if complete
        if (complete)
        {
            PlayerPrefs.SetInt("cabinetOpen", (complete ? 1 : 0));
            StartCoroutine(wait());
        }
    }

    void PlaySound()
    {
        cabinetAudio.Play();
        audioPlayed = true;
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        if (!audioPlayed) PlaySound();
        if (transform.position.z < 21.65f)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * 0.5f));
        }
    }
    
    private IEnumerator rotateLeft()
    {
        while (true)
        {
            LDoor.transform.RotateAround(rotationAxisLeft.position, rotationAxisLeft.up, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
    
    private IEnumerator rotateRight()
    {
        while (true)
        {
            RDoor.transform.RotateAround(rotationAxisRight.position, rotationAxisRight.up, -rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
