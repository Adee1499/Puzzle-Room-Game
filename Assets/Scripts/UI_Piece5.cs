using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Piece5 : MonoBehaviour
{
    public Sprite piece5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("tangram5") == 1)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = piece5;
        }
    }
}
