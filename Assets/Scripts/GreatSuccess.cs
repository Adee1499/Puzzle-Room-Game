using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreatSuccess : MonoBehaviour
{

    public GameObject pauseMenu;
    public TileMapMouse tileMapMouse;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tileMapMouse.complete)
        {
            PlayerPrefs.SetInt("nonogram", (tileMapMouse.complete ? 1 : 0));
            SceneManager.LoadScene("Scenes/MainRoomScene");
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
    }
}
