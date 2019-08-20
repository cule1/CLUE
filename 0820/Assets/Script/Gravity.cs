using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    private Rigidbody myRigi;
    private Collider myCol;

	// Use this for initialization
	void Start () {

        myRigi = GetComponent<Rigidbody>();
        myCol = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {

    
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CheckObject")
        {
            Debug.Log("aa");
            myRigi.isKinematic = false;

        }
    }
   
        

}
