using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardButton : MonoBehaviour {
    public GameObject Keyboard;

    private bool IsOn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if(IsOn)
  //      {
  //          Keyboard.SetActive(true);
  //      }
  //      else
  //      {
  //          Keyboard.SetActive(false);
  //      }
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GameObject1"
            || other.gameObject.name == "GameObject2")
        {
            if (!IsOn)
            {
                IsOn = true;
                Keyboard.SetActive(true);
            }
            else
            {
                IsOn = false;
                Keyboard.SetActive(false);
            }
        }
    }
}
