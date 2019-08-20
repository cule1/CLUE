using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardUIRay : MonoBehaviour {
    //public VRTK.VRTK_UIPointer ui_pointer;
    //public VRTK.VRTK_StraightPointerRenderer straight_pointer;
    //public VRTK.VRTK_Pointer pointer;
    public GameObject KeyboardUI;
    public GameObject PauseUI;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(KeyboardUI.activeSelf || PauseUI.transform.GetChild(0).gameObject.activeSelf
            || PauseUI.transform.GetChild(1).gameObject.activeSelf)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
	}
}
