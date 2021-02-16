using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Key : MonoBehaviour
{
    public Sprite key;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("cctvKey") == 1)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = key;
        }
    }
}
