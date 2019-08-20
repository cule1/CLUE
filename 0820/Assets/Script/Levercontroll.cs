using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levercontroll : MonoBehaviour {
    public GameObject key;
    public GameObject[] myLight = new GameObject[8];
    public bool istrigger=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // void OnTriggerEnter(Collider col)
    // {
    //     if(col.gameObject.tag=="CheckObject")
    //     {
    //       
    //        this.GetComponent<Animator>().SetTrigger("open");
    //     }
    //
    // }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "lever")
        {
              istrigger = true;
            key.gameObject.SetActive(true);

            key.GetComponent<Keypad>().enabled = true;
            myLight[0].GetComponent<Light>().enabled = true;
            myLight[1].GetComponent<Light>().enabled = true;
            myLight[2].GetComponent<Light>().enabled = true;
            myLight[3].GetComponent<Light>().enabled = true;
            myLight[4].GetComponent<Light>().enabled = true;
            myLight[5].GetComponent<Light>().enabled = true;
            myLight[6].GetComponent<Light>().enabled = true;
            myLight[7].GetComponent<Light>().enabled = true;

        }

    }



   
}
