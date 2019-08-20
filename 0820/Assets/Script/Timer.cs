using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    bool IsPause;

    // Use this for initialization
    void Start()
    {
             IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.T))
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            /*일시정지 활성화*/
            if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }

            /*일시정지 비활성화*/
            if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                return;
            }
        }
    }
}




