using UnityEngine;
using System.Collections;

public class Keypad : MonoBehaviour
{

    public string curPassword = "123";
    public string input;
    public int Add = 0;

    public bool onTrigger;
    public bool doorOpen;
    public bool keypadScreen;
    public GameObject Door;
    public GameObject Screen;
    public GameObject Exit;
    public GameObject Particle1;
    public Texture Nothing;
    public Texture T1;
    public Texture T2;
    public Texture T3;
   // public Texture T4;
    public Texture Incorrect;
    public bool Active = true;


    void OnTriggerEnter(Collider col)
    {
        onTrigger = true;
        keypadScreen = true;

        if (col.transform.tag == "1")
        {
            input = input + "1";
            Add += 1;
        }

        if (col.transform.tag == "2")
        {
            input = input + "2";
            Add += 1;
        }

        if (col.transform.tag == "3")
        {
            input = input + "3";
            Add += 1;
        }

        if (col.transform.tag == "4")
        {
            input = input + "4";
            Add += 1;
        }

        if (col.transform.tag == "5")
        {
            input = input + "5";
            Add += 1;
        }

        if (col.transform.tag == "6")
        {
            input = input + "6";
            Add += 1;
        }

        if (col.transform.tag == "7")
        {
            input = input + "7";
            Add += 1;
        }

        if (col.transform.tag == "8")
        {
            input = input + "8";
            Add += 1;
        }

        if (col.transform.tag == "9")
        {
            input = input + "9";
            Add += 1;
        }

        if (col.transform.tag == "0")
        {
            input = input + "0";
            Add += 1;
        }

        // if (col.transform.tag == "c")
        // {
        //     input = "";
        // }


    }

    void OnTriggerStay(Collider col)
    {
        onTrigger = true;
        keypadScreen = true;

        if (col.transform.tag == "1")
        {
            onTrigger = true;

        }

        if (col.transform.tag == "2")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "3")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "4")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "5")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "6")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "7")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "8")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "9")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "0")
        {
            onTrigger = true;
        }
  

    }
    void OnTriggerExit(Collider col)
    {
        onTrigger = true;
        keypadScreen = true;

        if (col.transform.tag == "1")
        {
            onTrigger = true;

        }

        if (col.transform.tag == "2")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "3")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "4")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "5")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "6")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "7")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "8")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "9")
        {
            onTrigger = true;
        }

        if (col.transform.tag == "0")
        {
            onTrigger = true;
        }

      

    }
    void Reset()
    {
        Add = 0;
        input = "";
        Screen.GetComponent<Renderer>().material.mainTexture = Nothing;

    }



    void Update()
    {
        if (Add == 0) { Screen.GetComponent<Renderer>().material.mainTexture = Nothing; }
        if (Add == 1) { Screen.GetComponent<Renderer>().material.mainTexture = T1; }
        if (Add == 2) { Screen.GetComponent<Renderer>().material.mainTexture = T2; }
        //if (Add == 3) { Screen.GetComponent<Renderer>().material.mainTexture = T3; }

        if (curPassword == input && Add == 3)
        {
            Screen.GetComponent<Renderer>().material.mainTexture = T3;

            doorOpen = true;
        }

        if (curPassword != input && Add == 3)
        {
            Screen.GetComponent<Renderer>().material.mainTexture = Incorrect;
        }

        if (curPassword != input && Add >= 4)
        {
            Reset();
        }

        //  if (input == curPassword)
        //  {
        //      doorOpen = true;
        //  }
        //
        if (doorOpen)
        {
            Door.gameObject.SetActive(true);

            Exit.gameObject.SetActive(true);
            Particle1.gameObject.SetActive(true);

        }
    }



}
