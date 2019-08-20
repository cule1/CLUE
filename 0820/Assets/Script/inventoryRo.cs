using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryRo : MonoBehaviour
{
    public GameObject Bord;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Bord.gameObject.transform.Rotate(0, 180, 0);
            
        }

       if (OVRInput.GetDown(OVRInput.Button.Three))
       {
           Bord.gameObject.transform.Rotate(0, -180, 0);
       }
    }

}

