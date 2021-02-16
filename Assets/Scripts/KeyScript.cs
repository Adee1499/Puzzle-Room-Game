using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Camera cameraFPS;
    public GameObject drawer;
    private bool open = false;
    public GameObject KeyNoDoorUI;
    public GameObject CCTVDoor;
    private bool doorFound = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("cctvKey") == 1) Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        open = drawer.GetComponent<DeskDrawer>().open;

        doorFound = CCTVDoor.GetComponent<CCTVDoor>().discoveredDoor;
        
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (open && GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && Input.GetMouseButtonDown(0))
        {
            PlayerPrefs.SetInt("cctvKey", 1);
            this.GetComponent<MeshRenderer>().enabled = false;
            if (!doorFound) KeyNoDoorUI.SetActive(true);
        }
    }
}