using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tangram5 : MonoBehaviour
{
    public Camera cameraFPS;
    public GameObject firstTangramUI;
    public GameObject secondTangramUI;
    public GameObject thirdTangramUI;
    public GameObject fourthTangramUI;
    public GameObject fifthTangramUI;
    public GameObject sixthTangramUI;
    public GameObject sofa;
    private bool solved = false;
    private AudioSource sound;
    private bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("tangram5") == 1) Destroy(this.gameObject);
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        solved = sofa.GetComponent<SofaCollisionDetection>().solved;

        if (solved)
        {
            StartCoroutine(wait());
        }
        
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (solved && GetComponent<Collider>().Raycast(ray, out hitInfo, 4) && Input.GetMouseButtonDown(0))
        {
            PlayerPrefs.SetInt("tangram5", 1);
            Destroy(this.gameObject);
            if ((PlayerPrefs.GetInt("tangram1") != 1) &&
                (PlayerPrefs.GetInt("tangram2") != 1) &&
                (PlayerPrefs.GetInt("tangram3") != 1) &&
                (PlayerPrefs.GetInt("tangram4") != 1) &&
                (PlayerPrefs.GetInt("tangram6") != 1))
            {
                firstTangramUI.SetActive(true);
                PlayerPrefs.SetInt("pieces", 1);
            }

            else if (PlayerPrefs.GetInt("pieces") == 1)
            {
                secondTangramUI.SetActive(true);
                PlayerPrefs.SetInt("pieces", 2);
            }
            
            else if (PlayerPrefs.GetInt("pieces") == 2)
            {
                thirdTangramUI.SetActive(true);
                PlayerPrefs.SetInt("pieces", 3);
            }
            
            else if (PlayerPrefs.GetInt("pieces") == 3)
            {
                fourthTangramUI.SetActive(true);
                PlayerPrefs.SetInt("pieces", 4);
            }
            
            else if (PlayerPrefs.GetInt("pieces") == 4)
            {
                fifthTangramUI.SetActive(true);
                PlayerPrefs.SetInt("pieces", 5);
            }
            
            else if (PlayerPrefs.GetInt("pieces") == 5)
            {
                sixthTangramUI.SetActive(true);
                PlayerPrefs.SetInt("pieces", 6);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "floor" && !soundPlayed)
        {
            sound.Play(0);
            soundPlayed = true;
        }
    }
    
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(11);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}