using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SafeKnob : MonoBehaviour
{
	public float speed = 10f;
	private int angleBehind = -30;
	private int angleInitial = 0;
	private int angleFinal = 30;
	private float angle = 0;
	private int dial;
	private Quaternion rotationBehind, rotationInitial, rotationFinal;
	private bool rotatingRight, rotatingLeft = false;
	private bool isOn1, isOn5, isOn11 = false;
	public bool correctCombination = false;
	public GameObject ALeftTrigger;
	public GameObject ARightTrigger;
	public Camera cameraFPS;
	public GameObject painting;
	private bool isFrameClosed;
	private AudioSource safeKnobAudio;
	
	void Start()
	{
		safeKnobAudio = GetComponent<AudioSource>();
		// initialize quaternion rotations
		rotationBehind = Quaternion.Euler(0, 91.702f, angleBehind);
		rotationInitial = Quaternion.Euler(0, 91.702f, angleInitial);
		rotationFinal = Quaternion.Euler(0, 91.702f, angleFinal);
	}
    void Update()
    {
	    Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
	    RaycastHit hitInfo;
	    
	    isFrameClosed = painting.GetComponent<OpenDoor>().closed;
	    
	    // update dial pointer (1 -> 12)
	    DialPointer(); 
	    
	    // check combination
	    CheckCombination();
	    
	    // left rotation
	    if (!isFrameClosed && !correctCombination && ALeftTrigger.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) && Input.GetMouseButtonDown(0))
	    {
		    rotatingLeft = true;
		    rotatingRight = false;
	        StartCoroutine(RotateOverTime(rotationInitial, rotationBehind, 1f / speed));
	        safeKnobAudio.Play(0);
	        UpdateLeftAngles();
		}
	    // right rotation
		if (!isFrameClosed && !correctCombination && ARightTrigger.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) && Input.GetMouseButtonDown(0))
		{
			rotatingRight = true;
			rotatingLeft = false;
			StartCoroutine(RotateOverTime(rotationInitial, rotationFinal, 1f / speed));
			safeKnobAudio.Play(0);
			UpdateRightAngles();
		}
    }

    void CheckCombination()
    {
	    // set bools true
	    if (dial == 1 && rotatingLeft) isOn1 = true;
	    if (isOn1 && dial == 5 && rotatingRight) isOn5 = true;
	    if (isOn1 && isOn5 && dial == 11) isOn11 = true;
	    
	    // set bools false
	    if (isOn1 && !isOn5 && rotatingRight) isOn1 = false;
	    if (isOn1 && isOn5 && !isOn11 && rotatingLeft) isOn5 = false;
	    
	    // final check
	    if (isOn1 && isOn5 && isOn11) correctCombination = true;
    }

    void DialPointer()
    {
	    angle = transform.rotation.eulerAngles.z;
	    if (angle >= 0 && angle < 5) dial = 12; // angle 0
	    else if (angle > 25 && angle < 35) dial = 1; // angle 30
	    else if (angle > 55 && angle < 65) dial = 2; // angle 60
	    else if (angle > 85 && angle < 95) dial = 3; // angle 90
	    else if (angle > 115 && angle < 125) dial = 4; // angle 120
	    else if (angle > 145 && angle < 155) dial = 5; // angle 150
	    else if (angle > 175 && angle < 185) dial = 6; // angle 180
	    else if (angle > 205 && angle < 215) dial = 7; // angle 210
	    else if (angle > 235 && angle < 245) dial = 8; // angle 240
	    else if (angle > 265 && angle < 275) dial = 9; // angle 270
	    else if (angle > 295 && angle < 305) dial = 10; // angle 300
	    else if (angle > 325 && angle < 335) dial = 11; // angle 330
    }

    void UpdateLeftAngles()
    {
	    angleFinal = angleInitial;
	    angleInitial = angleBehind;
	    angleBehind -= 30;
	    rotationBehind = Quaternion.Euler(0, 91.702f, angleBehind);
	    rotationInitial = Quaternion.Euler(0, 91.702f, angleInitial);
	    rotationFinal = Quaternion.Euler(0, 91.702f, angleFinal);
    }
    
    void UpdateRightAngles()
    {
	    angleBehind = angleInitial;
	    angleInitial = angleFinal;
	    angleFinal += 30;
	    rotationBehind = Quaternion.Euler(0, 91.702f, angleBehind);
		rotationInitial = Quaternion.Euler(0, 91.702f, angleInitial);
		rotationFinal = Quaternion.Euler(0, 91.702f, angleFinal);
    }

    IEnumerator RotateOverTime(Quaternion originalRotation, Quaternion finalRotation, float duration)
    {
	    if (duration > 0f)
	    {
		    float startTime = Time.time;
		    float endTime = startTime + duration;
		    transform.rotation = originalRotation;
		    yield return null;
		    while (Time.time < endTime)
		    {
			    float progress = (Time.time - startTime) / duration;
			    transform.rotation = Quaternion.Slerp(originalRotation, finalRotation, progress);
			    yield return null;
		    }
	    }
	    transform.rotation = finalRotation;
    }
}
