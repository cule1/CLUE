using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransform : MonoBehaviour {

    public GameObject Camera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position
                   = Camera.GetComponent<Camera>().transform.position + Camera.GetComponent<Camera>().transform.forward * 2.2f;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        transform.rotation
            = Quaternion.Euler(new Vector3(Camera.GetComponent<Camera>().transform.localEulerAngles.x, Camera.GetComponent<Camera>().transform.localEulerAngles.y + Camera.transform.parent.parent.parent.localEulerAngles.y, 0));
    }
}
