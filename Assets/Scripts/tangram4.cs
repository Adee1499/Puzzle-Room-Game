﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tangram4 : MonoBehaviour
{
    public Camera cameraFPS;
    public GameObject top;
    public GameObject firstTangramUI;
    public GameObject secondTangramUI;
    public GameObject thirdTangramUI;
    public GameObject fourthTangramUI;
    public GameObject fifthTangramUI;
    public GameObject sixthTangramUI;
    private bool chestOpen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("tangram4") == 1) Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        chestOpen = top.GetComponent<topChestOpen>().chestOpen;
        
        
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (chestOpen && GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("picking up piece 4");
            PlayerPrefs.SetInt("tangram4", 1);
            Destroy(this.gameObject);
            if ((PlayerPrefs.GetInt("tangram2") != 1) &&
                (PlayerPrefs.GetInt("tangram3") != 1) &&
                (PlayerPrefs.GetInt("tangram1") != 1) &&
                (PlayerPrefs.GetInt("tangram5") != 1) &&
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
}
