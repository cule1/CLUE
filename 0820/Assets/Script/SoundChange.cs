using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChange : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;

    public bool a2 = false;

    //public Chanel soundChange;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            room2.SetActive(true);
            room1.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "9")
        {
            room2.SetActive(true);
            room1.SetActive(false);
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "9")
        {
          
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "9")
        {
           
        }
    }
}