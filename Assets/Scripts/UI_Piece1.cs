using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UI_Piece1 : MonoBehaviour
{
    public Sprite piece1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("tangram1") == 1)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = piece1;
        }
    }
}
