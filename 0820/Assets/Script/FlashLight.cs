using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject battery;
    public Light flashlight;
    
    void Start()
    {
    }
    void Update()
    {
        
      
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Battery")
        {
            flashlight.enabled = true;

            collision.gameObject.SetActive(false);
        }
    }
}
