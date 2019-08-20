using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollision : MonoBehaviour
{

    public bool isOverraped = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "GameObject")
        {

            isOverraped = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "GameObject")
        {

            isOverraped = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

    }


    //Stay 충돌하고 있는 혹은 붙어있는 동안
    void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "GameObject")
        {
            isOverraped = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

}
