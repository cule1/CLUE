using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    
    public int TimeLimit;
    public bool IsPause { get; set; }
    public GameObject Camera;

    private float timeCnt;
    private float timeMin;
    private float timeSec;

    private bool SetPos = false;

	// Use this for initialization
	void Start () {
        IsPause = false;
        timeMin = TimeLimit;
    }
	
	// Update is called once per frame
	void Update () {
        if (IsPause)
        {
            if (!SetPos)
            {
                float y = transform.position.y;

                SetPos = true;
                transform.position
                   = Camera.GetComponent<Camera>().transform.position + Camera.GetComponent<Camera>().transform.forward;
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
                transform.rotation
                    = Quaternion.Euler(new Vector3(0, Camera.GetComponent<Camera>().transform.localEulerAngles.y + Camera.transform.parent.parent.localEulerAngles.y, 0));

            }
        }
        else
        {
            SetPos = false;
        }

        timeCnt += Time.deltaTime;

        if (timeSec < timeCnt)
        {
            timeMin -= 1;
            timeSec += 60.0f;
            timeSec = 60.0f - timeCnt;
            timeCnt -= Mathf.Floor(timeCnt);
        }
        else
        {
            timeSec = 60.0f - timeCnt;
        }

        string timestr = "";
        timestr = "" + timeSec.ToString("00.00");
        timestr = timestr.Replace(".", ":");
        transform.GetChild(0).Find("Text").GetComponent<Text>().text = "남은 시간 : " + timeMin + ":" + timestr;

        //if (Input.GetKeyDown(KeyCode.T))
        if(OVRInput.GetDown(OVRInput.Button.Start))
        {
            if(!IsPause)
            {
                //Time.timeScale = 0;
                IsPause = true;
                transform.GetChild(0).gameObject.SetActive(true);

                //timerUI.text = "Time : " + timestr;
                //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Time : " + timestr;
            }
            else
            {
                //Time.timeScale = 1;
                IsPause = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
