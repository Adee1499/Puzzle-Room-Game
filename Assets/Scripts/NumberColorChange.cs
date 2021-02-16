using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberColorChange : MonoBehaviour
{
    public GameObject number;
    private bool red = false;
    private bool white = true;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (white && Input.GetMouseButtonDown(0))
        {
            red = true;
            number.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

        if (red && Input.GetMouseButtonDown(1))
        {
            white = true;
            number.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }
}
