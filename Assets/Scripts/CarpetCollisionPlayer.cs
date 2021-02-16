using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetCollisionPlayer : MonoBehaviour
{
    private AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "player")
        {
            sound.Play(0);
        }
    }
}
