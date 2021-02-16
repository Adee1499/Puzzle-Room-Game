using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : MonoBehaviour
{
   private AudioSource lockedAudio;
   public Camera cameraFPS;
   
   // Start is called before the first frame update
   void Start()
   {
       lockedAudio = GetComponent<AudioSource>();
   }

   // Update is called once per frame
   void Update()
   { 
       Ray ray = cameraFPS.ScreenPointToRay(Input.mousePosition);
       RaycastHit hitInfo;

       if (GetComponent<Collider>().Raycast(ray, out hitInfo, 2) &&
           Input.GetMouseButtonDown(0))
       {
           Debug.Log("door");
           lockedAudio.Play(0);
       }
   }
       

}
