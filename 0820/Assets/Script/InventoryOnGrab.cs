using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InventoryOnGrab : MonoBehaviour {

	public GameObject panel;

	// Use this for initialization
	void Start () {
		GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += InteractableObjectGrabbedHandler;
		GetComponent<VRTK_InteractableObject>().InteractableObjectUnused += InteractableObjectUnGrabbedHandler;
		//GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += InteractableObjectGrabbedHandler;
	}
	
	void InteractableObjectGrabbedHandler(object sender, InteractableObjectEventArgs e)
	{
		OpenPanel();
	}

	void InteractableObjectUnGrabbedHandler(object sender, InteractableObjectEventArgs e)
	{
		ClosePanel();
	}

	void OpenPanel()
	{
		panel.SetActive(true);
	}

	void ClosePanel()
	{
		panel.SetActive(false);
	}
}
