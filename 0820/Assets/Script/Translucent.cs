using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translucent : MonoBehaviour
{

    private Renderer myRenderer;

    public Material[] mat;
    public Material[] originalMat;

    // Use this for initialization
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        Material[] material = GetComponent<MeshRenderer>().materials;


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CheckObject")
        {
            Material[] material = GetComponent<MeshRenderer>().materials;
            material[1] = originalMat[0];
            GetComponent<MeshRenderer>().materials = material;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "CheckObject")
        {
            Material[] material = GetComponent<MeshRenderer>().materials;
            material[1] = originalMat[0];
            GetComponent<MeshRenderer>().materials = material;



        }

    }
    //Stay 충돌하고 있는 혹은 붙어있는 동안
    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "CheckObject")
        {
            Material[] material = GetComponent<MeshRenderer>().materials;
            material[1] = mat[0];
            GetComponent<MeshRenderer>().materials = material;
        }
    }

}

