using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeout : MonoBehaviour
{
    private float sec = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(LateCall());
        }  
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }
}
