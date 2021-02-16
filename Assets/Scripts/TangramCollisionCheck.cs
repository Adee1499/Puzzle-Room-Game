using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangramCollisionCheck : MonoBehaviour
{
    public bool collision = false;
    public BoxCollider B;
    
    private void OnTriggerStay(Collider other)
    {
        if (other == B)
        {
            collision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == B)
        {
            collision = false;
        }
    }
}
