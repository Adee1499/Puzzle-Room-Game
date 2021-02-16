using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessCheck : MonoBehaviour
{
    private bool success = false;
    public GameObject matrixTune;
    private AudioSource matrixSound;
    public GameObject pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        matrixTune = GameObject.Find("MatrixTune");
        matrixSound = matrixTune.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        success = (PlayerPrefs.GetInt("HackDone") != 0);
        if (success)
        {
            StartCoroutine(FadeAudioSource.StartFade(matrixSound, 5f, 0.001f));
            StartCoroutine(wait());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
        
        
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        Destroy(matrixTune);
        SceneManager.LoadScene("Scenes/MainRoomScene");
    }
}
