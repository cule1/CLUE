using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawercontroller : MonoBehaviour {

    
   void OnTriggerEnter(Collider col)
   {
       if(col.gameObject.tag=="CheckObject")
       {
         
          this.GetComponent<Animator>().SetTrigger("open");
       }
   
   }

   // void OnTriggerStay(Collider col)
   // {
   //     if (col.gameObject.tag == "CheckObject")
   //     {
   // 
   //         this.GetComponent<Animator>().SetTrigger("open");
   //     }
   // 
   // }


   // void OnTriggerExit(Collider col)
   // {
   //     if (col.gameObject.tag == "CheckObject")
   //     {
   //         this.GetComponent<Animator>().SetTrigger("close");
   //     }
   // 
   // }
}
