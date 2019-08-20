using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoon : MonoBehaviour {
    public bool istrigger = false;
    public GameObject moveMoon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="CheckObject")
        {
            istrigger = true;
            moveMoon.GetComponent<Collider>().enabled = true;
            moveMoon.GetComponent<Animator>().SetTrigger("move");
        }
        moveMoon.GetComponent<Animator>().enabled = true;
    }
}
