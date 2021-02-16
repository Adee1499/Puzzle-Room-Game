using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public bool[] array;
    private int noOfChildren;
    public GameObject[] children;
    public ColliderCubeScript[] scriptArray;
    
    // Start is called before the first frame update
    void Start()
    {
        noOfChildren = gameObject.transform.childCount;
        children = new GameObject[noOfChildren];
        array = new bool[noOfChildren];
        scriptArray = new ColliderCubeScript[noOfChildren];
        for (int c = 0; c < noOfChildren; c++)
        {
            children[c] = transform.GetChild(c).gameObject;
            scriptArray[c] = children[c].GetComponent<ColliderCubeScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < noOfChildren; i++)
        {
            array[i] = scriptArray[i].collision;
        }

        // Debug.Log(AreAllBoolTrue());
    }

    public bool AreAllBoolTrue()
    {
        for (int i = 0; i < noOfChildren; i++)
        {
            if (array[i] == false)
            {
                return false;
            }
        }

        return true;
    }
    
    public bool AreAllBoolFalse()
    {
        for (int i = 0; i < noOfChildren; i++)
        {
            if (array[i] == true)
            {
                return false;
            }
        }

        return true;
    }
}
