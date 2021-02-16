using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenChest : MonoBehaviour
{
    public Transform rotationAxis;
    private float rotationSpeed = 0.35f;
    private IEnumerator coroutineOpen;
    
    // check scripts
    public GameObject square1;
    public GameObject square2;

    private bool square1Solved = false;
    private bool square2Solved = false;
    public bool complete = false;
    private bool open = false;

    public AudioSource openChestSound;
    
    // Start is called before the first frame update
    void Start()
    {
        coroutineOpen = rotate();
    }

    // Update is called once per frame
    void Update()
    {
        square1Solved = square1.GetComponent<NumbersCheck1>().solved1;
        square2Solved = square2.GetComponent<NumbersCheck2>().solved2;
        if (square1Solved && square2Solved) complete = true;

        // debug
        float angle = transform.rotation.eulerAngles.x;

        if (!open && complete)
        {
            StartCoroutine(wait());
            //StartCoroutine(coroutineOpen);
        }

        if (angle <= 290 && angle > 280)
        {
            StopCoroutine(coroutineOpen);
            open = true;
            PlayerPrefs.SetInt("magicSquares", (open ? 1 : 0));
            SceneManager.LoadScene("Scenes/MainRoomScene");
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private IEnumerator rotate()
    {
        openChestSound.Play(0);
        while (true)
        {
            transform.RotateAround(rotationAxis.position, rotationAxis.right, -rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(coroutineOpen);
    }
}
