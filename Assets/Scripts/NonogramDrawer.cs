using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonogramDrawer : MonoBehaviour
{
    private bool nonogramComplete = false;
    public Transform drawer;
    private Vector3 targetPosition;
    public bool drawerOpen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nonogramComplete = (PlayerPrefs.GetInt("nonogram") != 0);
        // if (nonogramComplete)
        // {
        //     Vector3 closed = drawer.position;
        //     Vector3 open = new Vector3(13.4f, 1.2f, 32.9f);
        //     drawer.position = open;
        // }
        
        
        if (nonogramComplete)
        {
            if (drawer.position.z > 33f)
            {
                drawer.Translate(Vector3.forward * (Time.deltaTime * 0.3f));
            }

            drawerOpen = true;
        }
    }
}
