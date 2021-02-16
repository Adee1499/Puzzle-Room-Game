using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mouseSensitivity = 50f;
    public Transform playerBody;
    public Texture2D cursorNormalTexture;
    public Texture2D cursorHandTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Camera cameraFPS;
    
    // INTERACTABLE OBJECTS
    public GameObject painting;
    public GameObject monitor;
    public GameObject safeKnobLeft;
    public GameObject safeKnobRight;
    public GameObject safeHand;
    public GameObject nonogram;
    public GameObject cabinetDoorLeft;
    public GameObject cabinetDoorRight;
    public GameObject gearLeft;
    public GameObject gearRight;
    public GameObject frontDoor;
    public GameObject deskDrawer;
    public GameObject key;
    public GameObject tangram1;
    public GameObject tangram2;
    public GameObject tangram3;
    public GameObject tangram4;
    public GameObject tangram5;
    public GameObject tangram6;
    public GameObject CCTVDoor;
    public GameObject magicChest;
    public GameObject CRTMonitor;
    public GameObject cogInstructions;
    public GameObject fireplace;

    public GameObject pauseMenu;

    private bool cameraActive = true;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorNormalTexture, Vector2.zero, cursorMode);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraActive = (cameraFPS.targetDisplay == 0);
        
        if (cameraActive && !pauseMenu.activeInHierarchy)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);


            // Change to hand on hover over interactable object
            Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;


            if (painting.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) || 
                monitor.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                safeKnobLeft.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) || 
                safeKnobRight.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) || 
                safeHand.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) || 
                nonogram.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) || 
                cabinetDoorLeft.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) || 
                cabinetDoorRight.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) || 
                gearLeft.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) || 
                gearRight.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) || 
                frontDoor.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) || 
                deskDrawer.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                key.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                tangram1.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                tangram2.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                tangram3.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                tangram4.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                tangram5.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                tangram6.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                CCTVDoor.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) || 
                magicChest.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) || 
                CRTMonitor.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) ||
                cogInstructions.GetComponent<Collider>().Raycast(ray, out hitInfo, 2))
            {
                Cursor.SetCursor(cursorHandTexture, Vector2.zero, cursorMode);
            }
            
            if (!painting.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) && 
                !monitor.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && 
                !safeKnobLeft.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) && 
                !safeKnobRight.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) && 
                !safeHand.GetComponent<Collider>().Raycast(ray, out hitInfo, 1) && 
                !nonogram.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && 
                !cabinetDoorLeft.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && 
                !cabinetDoorRight.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && 
                !gearLeft.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && 
                !gearRight.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && 
                !frontDoor.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && 
                !deskDrawer.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) &&
                !key.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && 
                !tangram1.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && 
                !tangram2.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && 
                !tangram3.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && 
                !tangram4.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && 
                !tangram5.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && 
                !tangram6.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && 
                !CCTVDoor.GetComponent<Collider>().Raycast(ray, out hitInfo, 3) && 
                !magicChest.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) && 
                !CRTMonitor.GetComponent<Collider>().Raycast(ray, out hitInfo, 2) &&
                !cogInstructions.GetComponent<Collider>().Raycast(ray, out hitInfo, 2))
            {
                Cursor.SetCursor(cursorNormalTexture, Vector2.zero, cursorMode);
            } 
        }

        Cursor.lockState = pauseMenu.activeInHierarchy ? CursorLockMode.None : CursorLockMode.Locked;

        if (!cameraActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            if (!pauseMenu.activeInHierarchy) Cursor.lockState = CursorLockMode.Locked;
        }

        // REMOVE IN PRODUCTION
        //Cursor.visible = true;
        
        
        
        
        
    }
}
