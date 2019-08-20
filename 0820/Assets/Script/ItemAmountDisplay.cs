using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAmountDisplay : MonoBehaviour {

	private Camera _camera;

	// Use this for initialization
	void OnEnable () {
		StartCoroutine(FindMainCamera());
	}

	IEnumerator FindMainCamera()
	{
		while(_camera == null)
		{
			_camera = Camera.main;
			yield return new WaitForEndOfFrame();
		}
		print("Camera found: " + _camera);
		StartCoroutine(LookAtCamera());
	}
	
	// Update is called once per frame
	IEnumerator LookAtCamera () {
		while(true)
		{
			transform.LookAt(_camera.transform, Vector3.up);
			yield return new WaitForEndOfFrame();
		}
		
	}
}
