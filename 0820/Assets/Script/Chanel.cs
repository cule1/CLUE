using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chanel : MonoBehaviour{

    public bool isOver= false;

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
        if (collision.gameObject.tag == "1")
        {
            isOver = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "1")
        {
            isOver = false;
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "1")
        {
            isOver = true;
        }
    }
}