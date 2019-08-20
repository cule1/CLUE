using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLine : MonoBehaviour
{

    public bool isOverraped = false;

    private Renderer myRenderer;

    public Material newOutline;
    private Material originalOutline;

    // Use this for initialization
    void Start()
    {

        myRenderer = GetComponent<Renderer>();
        originalOutline = myRenderer.material;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CheckObject")
        {

            isOverraped = true;
            myRenderer.material = newOutline;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "CheckObject")
        {

            isOverraped = false;
            myRenderer.material = originalOutline;
        }

    }


    //Stay 충돌하고 있는 혹은 붙어있는 동안
    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "CheckObject")
        {

            isOverraped = true;
            myRenderer.material = newOutline;

        }
    }

}


