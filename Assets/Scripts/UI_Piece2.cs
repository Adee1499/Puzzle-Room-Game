using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Piece2 : MonoBehaviour
{
    public Sprite piece2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("tangram2") == 1)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = piece2;
        }
    }
}
