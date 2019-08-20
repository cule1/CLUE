using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour {

    public Chanel chanel;
    public GameObject Moniter;


    private Renderer myRenderer;

    public Material[] Mat;
    public Material[] originalMat;//고흐
   

    // Use this for initialization
    void Start()
    {
        myRenderer = Moniter.gameObject.GetComponent<Renderer>();
        Material[] material = Moniter.gameObject.GetComponent<MeshRenderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {
   
        int count = 0;

            if (chanel.isOver == true)
            {
                count++;
            Debug.Log("aa"); 
            }

        if (count==1) //1
        {
            Debug.Log("1");
            Material[] material = Moniter.gameObject.GetComponent<MeshRenderer>().materials;
            material[1] = originalMat[0];
           Moniter.gameObject.GetComponent<MeshRenderer>().materials = material;
        }
       if(count==2)//2
        {
            Debug.Log("2");
            Material[] material = Moniter.gameObject.GetComponent<MeshRenderer>().materials;
            material[1] = Mat[0];
           // Moniter.gameObject.GetComponent<MeshRenderer>().materials = material;
        }
        if (count==3)//3
        {
            Debug.Log("3");
            Moniter.SetActive(false);
        }
        if (count==4)//4
        {
            Debug.Log("4");
            Moniter.SetActive(true);
        }

        if(count==5||count>5)
        {
            count = 0;
        }



    }
 
}
