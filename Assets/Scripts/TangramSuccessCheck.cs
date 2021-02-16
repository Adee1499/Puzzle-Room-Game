using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangramSuccessCheck : MonoBehaviour
{
    public GameObject A1;
    public GameObject B1;
    public GameObject B2;
    public GameObject C3;
    public GameObject D3;
    public GameObject B4;
    public GameObject B5;

    private bool a1;
    private bool b1;
    private bool b2;
    private bool c3;
    private bool d3;
    private bool b4;
    private bool b5;

    public GameObject canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a1 = A1.GetComponent<TangramCollisionCheck>().collision;
        b1 = B1.GetComponent<TangramCollisionCheck>().collision;
        b2 = B2.GetComponent<TangramCollisionCheck>().collision;
        c3 = C3.GetComponent<TangramCollisionCheck>().collision;
        d3 = D3.GetComponent<TangramCollisionCheck>().collision;
        b4 = B4.GetComponent<TangramCollisionCheck>().collision;
        b5 = B5.GetComponent<TangramCollisionCheck>().collision;

        if (a1 && b1 && b2 && c3 && d3 && b4 && b5)
        {
            StartCoroutine(Wait());
        }
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        canvas.SetActive(true);
        Time.timeScale = 0;
    }
}
