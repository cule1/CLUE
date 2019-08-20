using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintManager : MonoBehaviour {

    public Print prints;
    public Print1 prints1;
    public Print2 prints2;
    public Print3 prints3;
    public Print4 prints4;
    public Print5 prints5;

    public MeshRenderer[] myrederer;
    public GameObject[] myGameobject;
    public AudioSource audio1; 
    public GameObject Back;

    public GameObject room1;
    public GameObject room2;

    public bool isGameOver;
    // Use this for initialization
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    { 
       // if (isGameOver == true)
       // {
       //     return;
       // }
        int count = 0;
       // for (int i = 0; i < 1; i++)
        //{
            if (prints.isOverraped == true)
            {
                count++;
            myrederer[0].enabled = true;
            myGameobject[0].gameObject.SetActive(false);


            }
            if (prints1.isOverraped == true)
            {
                count++;
            myrederer[1].enabled = true;
            myGameobject[1].gameObject.SetActive(false);
        }
            if (prints2.isOverraped == true)
            {
                count++;
            myrederer[2].enabled = true;
            myGameobject[2].gameObject.SetActive(false);
        }
            if (prints3.isOverraped == true)
            {
                count++;
            myrederer[3].enabled = true;
            myGameobject[3].gameObject.SetActive(false);
        }
            if (prints4.isOverraped == true)
            {
                count++;
            myrederer[4].enabled = true;
            myGameobject[4].gameObject.SetActive(false);
        }
            if (prints5.isOverraped == true)
            {
                count++;
            myrederer[5].enabled = true;
            myGameobject[5].gameObject.SetActive(false);
        }

      //  }
        if (count >= 6)
        {
            isGameOver = true;
        }
        if(isGameOver==true|| Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("bb");
            //this.GetComponent<Animator>().SetTrigger("Closet");
            Invoke("Aa", 5);
            Invoke("Bb", 7);
        }
    }
    void Aa()
    {
        Back.GetComponent<Animator>().SetTrigger("aa");
        audio1.enabled = true;
        room1.gameObject.SetActive(false);

    }

    void Bb()
    {
      
        room2.gameObject.SetActive(true);
    }

}

