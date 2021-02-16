using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Piece3 : MonoBehaviour
{
    public Sprite piece3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("tangram3") == 1)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = piece3;
        }
    }
}
