using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskDrawer : MonoBehaviour
{
    private Vector3 targetPosition;
    public Camera cameraFPS;
    public bool open = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        if (!open && GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && Input.GetMouseButtonDown(0))
        {
            open = true;
        }
        
        if (open)
        {
            if (transform.position.x > 0.36367f)
            {
                transform.Translate(Vector3.down * (Time.deltaTime * 0.5f));
            }
            else
            {
                open = true;
            }
        }
    }

    
}