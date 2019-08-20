using UnityEngine;
using System.Collections;

public class IronDoor : MonoBehaviour
{

    public bool onTrigger;
    public bool doorOpen;

    public Transform doorHinge;
    public GameObject lock1;
    public int count=0;
    public int countNumber =5;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider col)
   {
       if (col.transform.tag == "stone")
       {
            onTrigger = true;
            count = count + 1;
        }
  
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.transform.tag == "stone")
        {
            onTrigger = true;
            count = count + 0;
        }

    }


    private void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "stone")
        {
            onTrigger = true;
            count = count + 0;
        }

    }

    void Update()
    {
        
        if (count==countNumber)
        {
            var newRot = Quaternion.RotateTowards(doorHinge.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
            doorHinge.rotation = newRot;
            Destroy(lock1);
        }
    }

}
