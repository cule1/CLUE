using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour {

    public bool isOverraped = false;



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
            Debug.Log("aa");
            isOverraped = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "1")
        {
            isOverraped = false;
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "1")
        {
            isOverraped = true;
        }
    }





}

