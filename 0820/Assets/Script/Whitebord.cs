using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whitebord : MonoBehaviour
{
    public GameObject WhiteBord;
    public GameObject Pen;
    public GameObject Camera;
    public GameObject BoardUI;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 현재 상태 : 아예 카메라 고정해서 따라다님
        WhiteBord.GetComponent<Whiteboard>().fixedPos
                   = Camera.GetComponent<Camera>().transform.position + Camera.GetComponent<Camera>().transform.forward * 0.4f;
        WhiteBord.GetComponent<Whiteboard>().fixedRot
            = Quaternion.Euler(new Vector3(Camera.GetComponent<Camera>().transform.localEulerAngles.x - 90.0f, Camera.GetComponent<Camera>().transform.localEulerAngles.y + Camera.transform.parent.parent.localEulerAngles.y, 0));

        if (OVRInput.GetDown(OVRInput.Button.One) && !WhiteBord.gameObject.activeSelf)
        //if (Input.GetKeyDown(KeyCode.G) && !WhiteBord.gameObject.activeSelf)
        {
            WhiteBord.gameObject.SetActive(true);
            Pen.gameObject.SetActive(true);
            BoardUI.gameObject.SetActive(true);


            if (!WhiteBord.GetComponent<Whiteboard>().IsfixedPos)
            {
                WhiteBord.GetComponent<Whiteboard>().IsfixedPos = true;
            }
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && WhiteBord.gameObject.activeSelf)
        //else if (Input.GetKeyDown(KeyCode.H) && WhiteBord.gameObject.activeSelf)
        {
            WhiteBord.gameObject.SetActive(false);
            Pen.gameObject.SetActive(false);
            BoardUI.gameObject.SetActive(false);

            WhiteBord.GetComponent<Whiteboard>().IsfixedPos = false;
        }


    }
}
