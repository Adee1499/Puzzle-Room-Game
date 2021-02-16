using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVDoor : MonoBehaviour
{

    private AudioSource lockedAudio;
    public Camera cameraFPS;
    private bool keyFound = false;
    public GameObject UIKeySilhouette;
    public bool discoveredDoor = false;
    public GameObject unlockSound;
    private AudioSource unlockAudio;
    public Transform rotationAxis;
    private float rotationSpeed = 25f;
    private bool open = false;
    private IEnumerator openCoroutine;
    private bool opening = false;
    public GameObject DoorNoKeyUI;
    
    // Start is called before the first frame update
    void Start()
    {
        lockedAudio = GetComponent<AudioSource>();
        unlockAudio = unlockSound.GetComponent<AudioSource>();
        openCoroutine = OpenDoor();

        if (PlayerPrefs.GetInt("cctvDoorOpen") == 1)
        {
            transform.position = new Vector3(13.65707f, -4.548913f, 32.75076f);
            transform.rotation = new Quaternion(0f, -0.5796512f, 0f, 0.8148649f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        keyFound = (PlayerPrefs.GetInt("cctvKey") != 0);

        if (keyFound) discoveredDoor = true;

        if (discoveredDoor) UIKeySilhouette.SetActive(true);
        
        if (discoveredDoor && !keyFound) DoorNoKeyUI.SetActive(true);

        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (!open && !keyFound && GetComponent<Collider>().Raycast(ray, out hitInfo, 3) &&
            Input.GetMouseButtonDown(0))
        {
            lockedAudio.Play(0);

            if (!discoveredDoor)
            {
                discoveredDoor = true;
            }
        }

        if (!opening && !open && keyFound && GetComponent<Collider>().Raycast(ray, out hitInfo, 3) &&
            Input.GetMouseButtonDown(0))
        {
            unlockAudio.Play(0);
            opening = true;
            StartCoroutine(openCoroutine);
        }
        
        if (transform.rotation.eulerAngles.y <= 290 && transform.rotation.eulerAngles.y >= 280)
        {
            StopCoroutine(openCoroutine);
            open = true;
        }

        if (open)
        {
            PlayerPrefs.SetInt("cctvDoorOpen", 1);
        }
    }

    private IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            transform.RotateAround(rotationAxis.position, rotationAxis.up, -rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

}
