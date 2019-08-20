using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class ChanelManager : MonoBehaviour {

    public Chanel[] chanel;
    public GameObject locks;
    public bool isGameOver;
    public AudioSource sound;

    public GameObject[] lock1;
    public MeshRenderer[] lock2;


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
         for (int i = 0; i < 4; i++)
       {
            if (chanel[i].isOver == true)
        {
            count++;
        }
       

         }
        if (count >= 4)
        {
            isGameOver = true;
        }
        if (isGameOver == true)
        {

            //this.GetComponent<Animator>().SetTrigger("Closet");
            //locks.gameObject.SetActive(true);
            sound.enabled = true;
            Invoke("Aa", 1);
        }
    }
    void Aa()
    {
        locks.GetComponent<Animator>().SetTrigger("open");

        for (int i = 0; i < 4; i++)
        {
            lock1[i].gameObject.SetActive(false);
        }


        for (int i = 0; i < 4; i++)
        {
            lock2[i].enabled = true;
        }
    }
}
