using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    public GameObject Player;
    public GameObject Board;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (OVRInput.GetDown(OVRInput.Button.Three))
        //{
        //
        //    Player.gameObject.transform.Rotate(0, 10, 0);
        //
        //}

        if (!Board.gameObject.activeSelf)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
            {
                Player.gameObject.transform.SetPositionAndRotation(Player.transform.position, Quaternion.Euler(0, Player.transform.localEulerAngles.y + 30, 0));

            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch))
            {
                Player.gameObject.transform.Rotate(0, -30, 0);

            }
        }
    }
}

