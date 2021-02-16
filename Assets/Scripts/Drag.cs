using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(MeshCollider))]
 
public class Drag : MonoBehaviour 
{
 
    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject top;
    private bool completed = false;
    private bool complete = false;
    private Rigidbody rBody;

    public GameObject pauseMenu;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    
    void OnMouseDown()
    {
        if (!complete && !pauseMenu.activeInHierarchy)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                         screenPoint.z));
        }
    }
 
    void OnMouseDrag()
    {
        if (!complete && !pauseMenu.activeInHierarchy)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        
        if (!complete && !pauseMenu.activeInHierarchy) transform.position = new Vector3(transform.position.x, transform.position.y, -20.6f);
        
        completed = top.GetComponent<OpenChest>().complete;
        if (completed) StartCoroutine(wait());
        
        // turn off rigidbody
        if (complete)
        {
            Destroy(rBody);
        }
    }
    
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        complete = true;
    }
 
}