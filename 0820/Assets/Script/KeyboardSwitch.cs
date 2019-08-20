using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSwitch : MonoBehaviour {
    public GameObject Keyboard;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "GameObject1")
        {
            if(!Keyboard.activeSelf)
                Keyboard.SetActive(true);
            else
                Keyboard.SetActive(false);
        }
    }
}
