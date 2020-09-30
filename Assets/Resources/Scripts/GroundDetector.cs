using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
   public bool isGrounded;

   private void OnCollisionEnter2D(Collision2D coll) 
   {
        if(coll.gameObject.tag=="Platform")
            isGrounded=true;
   }
   private void OnCollisionExit2D(Collision2D coll) 
   {
        if(coll.gameObject.tag=="Platform")
            isGrounded=false;
   }
}
