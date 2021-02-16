using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour
{
    TileMap _tileMap;
    
    Vector3 currentTileCoord;

    public Transform selectionTile;
    public GameObject selectionCube;

    public Transform blackTile;
    public GameObject blackCube;

    public Transform crossTile;
    public GameObject crossCube;

    public Detection detectionScript;

    public ColliderCheck colliderCheckScript;
    public ColliderCheck wrongColliderScript;

    public bool success;
    public bool complete;

    public GameObject pauseMenu;

    bool black;
    bool cross;
    
    void Start()
    {
        _tileMap = GetComponent<TileMap>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        
        black = detectionScript.black;
        cross = detectionScript.cross;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (!pauseMenu.activeInHierarchy && GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            int x = Mathf.FloorToInt(hitInfo.point.x / _tileMap.tileSize);
            int z = Mathf.FloorToInt(hitInfo.point.z / _tileMap.tileSize);

            // Debug.Log(x + " " + z);

            currentTileCoord.x = x;
            currentTileCoord.z = z;

            selectionCube.SetActive(true);
            selectionTile.transform.position = currentTileCoord;
            
            if (!success & Input.GetMouseButtonDown(0) & detectionScript.overlapCube == null)
            {
                Instantiate(blackTile, currentTileCoord, Quaternion.identity);
            }

            if (!success & Input.GetMouseButtonDown(1) & detectionScript.overlapCube == null)
            {
                Instantiate(crossTile, currentTileCoord, Quaternion.identity);
            }
        }
        else
        {
            selectionCube.SetActive(false);
        }

        if (colliderCheckScript.AreAllBoolTrue() && wrongColliderScript.AreAllBoolFalse())
        {
            success = true;
        }
        else
        {
            success = false;
        }

        if (success) StartCoroutine(Complete());

    }

    IEnumerator Complete()
    {
        yield return new WaitForSeconds(1);
        complete = true;
    }
}
