using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMagicSquares : MonoBehaviour
{
    public Camera cameraFPS;
    public GameObject player;
    public GameObject top;
    private bool open = false;
    private GameObject matrixTune;
    
    // Start is called before the first frame update
    void Start()
    {
        matrixTune = GameObject.Find("MatrixTune");
    }

    // Update is called once per frame
    void Update()
    {
        open = top.GetComponent<topChestOpen>().chestOpen;
        
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (!open && GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && Input.GetMouseButtonDown(0))
        {
            //Sets Position
            PlayerPrefs.SetFloat ("x", player.transform.position.x);
            PlayerPrefs.SetFloat ("y", player.transform.position.y);
            PlayerPrefs.SetFloat ("z", player.transform.position.z);
            //Sets Rotation
            PlayerPrefs.SetFloat ("rotx", player.transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat ("roty", player.transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat ("rotz", player.transform.rotation.eulerAngles.z);
            
            Destroy(matrixTune);
            
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Scenes/ChestScene");
        }
    }
}
