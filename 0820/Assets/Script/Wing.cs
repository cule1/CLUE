using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour {
    public bool isOverraped = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "stick")
        {

            isOverraped = true;
            this.gameObject.GetComponent<Collider>().enabled=false;

        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "stick")
        {

            isOverraped = false;
            this.gameObject.GetComponent<Collider>().enabled = false;

        }
    }

        //Stay 충돌하고 있는 혹은 붙어있는 동안
        private void OnCollisionStay(Collision other)
       {
        if (other.transform.tag == "stick")
         {
            isOverraped = true;
            this.gameObject.GetComponent<Collider>().enabled = false;
            }
    }

}
