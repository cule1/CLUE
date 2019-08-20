using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {
   public bool istrigger = false;
    public int count = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "stick")
        {
            istrigger = true;
            count = count + 1;

            if (count >=3)
            {
                this.GetComponent<Animator>().SetTrigger("stop");
            }
        }

    }
}
