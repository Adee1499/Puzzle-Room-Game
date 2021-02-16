using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCursorCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Cursor.lockState);
    }
}
