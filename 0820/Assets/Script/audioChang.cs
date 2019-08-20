using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioChang : MonoBehaviour {

    public bool isOver = false;

    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "a")
        {
            isOver = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "a")
        {
            isOver = false;
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "a")
        {
            isOver = true;
        }
    }
}