using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCubeScript : MonoBehaviour
{
    private bool triggered = false;
    public bool collision;
    private Collider other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && !other)
        {
            collision = false;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        triggered = true;
        this.other = other;
        if (other.tag == "Black")
        {
            collision = true;
        }
    }
    
}
