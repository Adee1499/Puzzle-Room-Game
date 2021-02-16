using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Piece6 : MonoBehaviour
{
    public Sprite piece6;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("tangram6") == 1)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = piece6;
        }
    }
}
