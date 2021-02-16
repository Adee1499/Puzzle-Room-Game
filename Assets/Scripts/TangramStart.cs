using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TangramStart : MonoBehaviour
{
    public Camera cameraFPS;
    private bool hackDone = false;
    private bool allPieces = false;
    public GameObject podiumUI;
    
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        hackDone = (PlayerPrefs.GetInt("HackDone") != 0);
        
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (PlayerPrefs.GetInt("tangram1") == 1 &&
            PlayerPrefs.GetInt("tangram2") == 1 &&
            PlayerPrefs.GetInt("tangram3") == 1 &&
            PlayerPrefs.GetInt("tangram4") == 1 &&
            PlayerPrefs.GetInt("tangram5") == 1 &&
            PlayerPrefs.GetInt("tangram6") == 1)
        {
            allPieces = true;
        }
        
        
        if (allPieces && hackDone && GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Scenes/TangramScene");
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (!allPieces && GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && Input.GetMouseButtonDown(0))
        {
            podiumUI.SetActive(true);
        }
    }
}
