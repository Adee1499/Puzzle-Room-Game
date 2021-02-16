using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public bool black = false;
    public bool cross = false;

    public GameObject overlapCube;
    private GameObject parent;

    public TileMapMouse tileMapMouseScript;
    private bool success;
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Black")
        {
            black = true;
            overlapCube = other.gameObject;

        }
        else if (other.tag == "Cross")
        {
            cross = true;
            overlapCube = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Black")
        {
            black = false;
            overlapCube = null;
        }
        else if (other.tag == "Cross")
        {
            cross = false;
            overlapCube = null;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        success = tileMapMouseScript.success;
        if (!success & (Input.GetMouseButtonDown(0) | Input.GetMouseButtonDown(1)))
        {
            Destroy(overlapCube);
            // Debug.Log("Destroyed");
        }
    }
}
