using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogInstructions : MonoBehaviour
{
    public GameObject instructions;
    public Camera cameraFPS;
    private bool open = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (!open && GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && Input.GetMouseButtonDown(0))
        {
            instructions.SetActive(true);
            Cursor.visible = false;
            StartCoroutine(LateCallTrue());
        }

        if (open && Input.GetMouseButtonDown(0))
        {
            instructions.SetActive(false);
            Cursor.visible = true;
            StartCoroutine(LateCallFalse());
        }
    }
    
    IEnumerator LateCallTrue()
    {
        yield return new WaitForSeconds(1);
        open = true;
    }
    
    IEnumerator LateCallFalse()
    {
        yield return new WaitForSeconds(1);
        open = false;
    }
}
