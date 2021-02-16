using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topChestOpen : MonoBehaviour
{
    public bool chestOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chestOpen = (PlayerPrefs.GetInt("magicSquares") != 0);

        if (chestOpen)
        {
            transform.position = new Vector3(20.97683f, -3.440001f, 35.9381f);
            transform.rotation = new Quaternion(-0.047304f, 0.8091861f, 0.5819397f, 0.06577611f);
        }
    }
}
