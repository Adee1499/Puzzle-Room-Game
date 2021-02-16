using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform frame;
    public Transform rotationAxis;
    private float rotationSpeed = 35f;
    private IEnumerator coroutineOpen;
    private IEnumerator coroutineClose;
    //private bool open = false;
    public bool closed = true;
	private bool opening = false;
	public GameObject safeDoor;
	private bool isSafeClosed = true;
    public Camera cameraFPS;
    private AudioSource paintingAudio;
    private bool playerPrefsOpen;
    
    void Start()
    {
        paintingAudio = GetComponent<AudioSource>();
        coroutineOpen = rotate();
        coroutineClose = rotateClose();
        playerPrefsOpen = (PlayerPrefs.GetInt("painting") != 0);
        if (playerPrefsOpen)
        {
            transform.position = new Vector3(-1.58484f, 2.97803f, 30.42108f);
            transform.rotation = new Quaternion(0f, 0.7015232f, 0f, 0.7126467f);
        }
    }
    
    void Update ()
    {

        isSafeClosed = safeDoor.GetComponent<OpenSafe>().closed;

        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        float angleY = frame.rotation.eulerAngles.y;


        if (!opening && closed && GetComponent<Collider>().Raycast(ray, out hitInfo, 1) && Input.GetMouseButtonDown(0))
        {
			opening = true;
            StartCoroutine(coroutineOpen);
            paintingAudio.Play(0);
        }

        if (angleY <= 90)
        {
            StopCoroutine(coroutineOpen);
			opening = false;
            closed = false;
            PlayerPrefs.SetInt("painting", 1);
            //open = true;
        }
        
   //      if (isSafeClosed && !opening && open && GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity) && Input.GetMouseButtonDown(0))
   //      {
			// opening = true;
   //          StartCoroutine(coroutineClose);
   //      }

        if (angleY >= 181)
        {
            StopCoroutine(coroutineClose);
            opening = false;
			closed = true;
            //open = false;
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
}
