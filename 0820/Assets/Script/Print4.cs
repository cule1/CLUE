using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print4 : MonoBehaviour {

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
        if (collision.gameObject.tag == "5")
        {
            Debug.Log("aa");
            isOverraped = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "5")
        {
            isOverraped = false;
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "5")
        {
            isOverraped = true;
        }
    }





}

