using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light3 : MonoBehaviour {
    private Light theLight;
    private float targetIntensity;
    private float currentIntensity;

	// Use this for initialization
	void Start () {
        theLight = GetComponent<Light>();
        currentIntensity = theLight.intensity;
        targetIntensity =Random.Range(1f, 2f);
        
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(targetIntensity-currentIntensity)>=0.01)
        {
            if (targetIntensity - currentIntensity >= 0)
                currentIntensity += Time.deltaTime * 2f;
            else
                currentIntensity -= Time.deltaTime * 2f;

            theLight.intensity = currentIntensity;
            theLight.range = currentIntensity+5;
        }
        else
        {
            targetIntensity = Random.Range(1f, 2f);
        }
	}
}
