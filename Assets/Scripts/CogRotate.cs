using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogRotate : MonoBehaviour
{
    public GameObject ALeftTrigger;
    public GameObject ARightTrigger;
    public GameObject cogA;
    public GameObject cogB;
    public GameObject cogC;
    public Camera cameraFPS;
    
    private float lastTime;

    public int[] numA;
    private int cogANum;
    private int iA;
    public int[] numB;
    private int cogBNum;
    private int iB;
    public int[] numC;
    private int cogCNum;
    private int iC;

    private bool cabinetOpen = false;

    private AudioSource click;
    
    //private bool isAEven;
    //private bool isBEven;
    //private bool isMoving = false;
    public bool isComplete = false;
    
    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        numA = new int[] {1, 6, 9, 3, 8, 5, 7, 2, 4};
        iA = 0;
        cogANum = numA[iA];
        numB = new int[] {1, 8, 3, 7, 2, 4, 6, 9, 5};
        iB = 0;
        cogBNum = numB[iB];
        numC = new int[] {1, 9, 3, 8, 5, 7, 2, 6, 4};
        iC = 0;
        cogCNum = numC[iC];

        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (cogANum == 9 && cogBNum == 9 && cogCNum == 9) Complete();
        cabinetOpen = (PlayerPrefs.GetInt("cabinetDoorOpen") != 0);
    }

    void Complete()
    {
        isComplete = true;
    }

    void Move()
    {
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (cabinetOpen && !isComplete && (Time.time - lastTime > 2.0f) && ALeftTrigger.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && Input.GetMouseButtonDown(0))
        {
            // cog A left
            // Debug.Log("left");
            // cogA.transform.Rotate( new Vector3(0, (cogA.transform.rotation.y) - 40, 0), Space.Self );
            
            StartCoroutine(RotateGearA(Vector3.down * 40, 1));
            click.Play(0);
            lastTime = Time.time;
            if (iA == 0)
            {
                iA = 8;
            }
            else
            {
                iA--;
            }
            cogANum = numA[iA];
            MoveGearB();
        }
        
        if (cabinetOpen && !isComplete && (Time.time - lastTime > 2.0f) && ARightTrigger.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && Input.GetMouseButtonDown(0))
        {
            // cog A right
            // Debug.Log("right");
            // cogA.transform.Rotate( new Vector3(0, (cogA.transform.rotation.y) + 40, 0), Space.Self );
            
            StartCoroutine(RotateGearA(Vector3.up * 40, 1));
            click.Play(0);
            //isMoving = false;
            lastTime = Time.time;
            if (iA == 8)
            {
                iA = 0;
            }
            else
            {
                iA++;
            }
            cogANum = numA[iA];
            MoveGearB();
        }
    }

    void MoveGearB()
    {
        if (cogANum % 2 == 0)
        {
            //isAEven = true;
            // rotate once clockwise
            // cogB.transform.Rotate( new Vector3(0, (cogB.transform.rotation.y) + 40, 0), Space.Self );
            StartCoroutine(RotateGearB(Vector3.up * 40, 1));
            if (iB == 8)
            {
                iB = 0;
            }
            else
            {
                iB++;
            }
            cogBNum = numB[iB];
            MoveGearC();
        }

        if (cogANum % 2 == 1)
        {
            //isAEven = false;
            // rotate twice anti-clockwise
            // cogB.transform.Rotate( new Vector3(0, (cogB.transform.rotation.y) - 80, 0), Space.Self );
            StartCoroutine(RotateGearB(Vector3.down * 80, 1));
            if (iB == 1)
            {
                iB = 8;
            }
            else if (iB == 0)
            {
                iB = 7;
            }
            else
            {
                iB -= 2;
            }
            cogBNum = numB[iB];
            MoveGearC();
        }
    }

    void MoveGearC()
    {
        if (cogBNum % 2 == 0)
        {
            //isBEven = true;
            // rotate x3 anti-clockwise
            // cogC.transform.Rotate(new Vector3(0, (cogC.transform.rotation.y) - 120, 0), Space.Self);
            StartCoroutine(RotateGearC(Vector3.up * 120, 2));
            //isMoving = false;
            if (iC == 6)
            {
                iC = 0;
            }
            else if (iC == 7)
            {
                iC = 1;
            }
            else if (iC == 8)
            {
                iC = 2;
            }
            else
            {
                iC += 3;
            }
            cogCNum = numC[iC];
        }

        if (cogBNum % 2 == 1)
        {
            //isBEven = false;
            // rotate x4 clockwise
            // cogC.transform.Rotate(new Vector3(0, (cogC.transform.rotation.y) + 160, 0), Space.Self);
            StartCoroutine(RotateGearC(Vector3.down * 160, 2));
            //isMoving = false;
            if (iC == 3)
            {
                iC = 8;
            }
            else if (iC == 2)
            {
                iC = 7;
            }
            else if (iC == 1)
            {
                iC = 6;
            }
            else if (iC == 0)
            {
                iC = 5;
            }
            else
            {
                iC -= 4;
            }
            cogCNum = numC[iC];
        }
    }
    
    // transform.Rotate( new Vector3(0, 5, 0), Space.Self );
    //
    IEnumerator RotateGearA(Vector3 byAngles, float inTime) {
        //isMoving = true;
        var fromAngle = cogA.transform.rotation;
        // var toAngle = Quaternion.Euler(cogA.transform.eulerAngles + byAngles);
        var toAngle = fromAngle * Quaternion.Euler(byAngles);
        for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
            cogA.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        cogA.transform.rotation = toAngle;
    }
    
    IEnumerator RotateGearB(Vector3 byAngles, float inTime) {
        var fromAngle = cogB.transform.rotation;
        // var toAngle = Quaternion.Euler(cogB.transform.eulerAngles + byAngles);
        var toAngle = fromAngle * Quaternion.Euler(byAngles);
        for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
            cogB.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        cogB.transform.rotation = toAngle;
    }
    
    IEnumerator RotateGearC(Vector3 byAngles, float inTime) {
        var fromAngle = cogC.transform.rotation;
        // var toAngle = Quaternion.Euler(cogC.transform.eulerAngles + byAngles);
        var toAngle = fromAngle * Quaternion.Euler(byAngles);
        for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
            cogC.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        cogC.transform.rotation = toAngle;
    }
    
}
