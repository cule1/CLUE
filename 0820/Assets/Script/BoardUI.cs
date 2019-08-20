using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(new Vector3(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y, 0));
	}
    
    /*public void OnEnterLeftButton()
    {
        GameObject.Find("ButtonLeft").transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Debug.Log("Enter Left Button");
    }

    public void OnExitLeftButton()
    {
        GameObject.Find("ButtonLeft").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Left Button");
    }

    public void OnClickLeftButton()
    {
        GameObject.Find("ButtonLeft").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Left Button Click");
    }

    public void OnEnterRightButton()
    {
        GameObject.Find("ButtonRight").transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Debug.Log("Enter Right Button");
    }

    public void OnExitRightButton()
    {
        GameObject.Find("ButtonRight").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Right Button");
    }

    public void OnClickRightButton()
    {
        GameObject.Find("ButtonRight").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Right Button Click");
    }*/
}
