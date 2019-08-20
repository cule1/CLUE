using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerIventory : MonoBehaviour {

    public OVRPlayerController player;
    public OVRGrabber leftHand;
    public OVRGrabber rightHand;
    public GameObject[] inventory = new GameObject[8];
    public GameObject[] inventoryHolder;
    private bool showingInventory = false;
    private float inventoryButtonReady = 0.0f;
    public Transform[] spawnPoints;


	// Use this for initialization
	void Start () {
        for (int i = 0; i < inventoryHolder.Length; i++)
        {
            inventoryHolder[i].transform.parent = transform;
            inventoryHolder[i].SetActive(false);
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        // 물건을 집고 b번튼을 누루면 인벤토리에 추가
        if(OVRInput.Get(OVRInput.Button.One))
        {
            OVRGrabber hand = getHoldingHand();
            if (hand != null && hand.grabbedObject != null && !showingInventory) {
                if (AddItem(hand.grabbedObject.gameObject))
                {
                    OVRGrabbable tempObj = hand.grabbedObject;
                    hand.ForceRelease(tempObj);
                    tempObj.gameObject.SetActive(false);
                }
            }
        }

        // 인벤을 보여주고 숨겨줌 0.25초동안 진행
        if (OVRInput.Get(OVRInput.Button.Three) && Time.time > inventoryButtonReady)
        {
            inventoryButtonReady = Time.time + 0.25f;
            showingInventory = !showingInventory;
            if (showingInventory)
            {
                showInventory();
            } else
            {
                hideInventory();
            }
            
        }

       ////트리거 누루면 인벤토리가 회전
       //if (showingInventory && (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) != 0 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) != 0))
       //{
       //    float inputValue = -OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) + OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
       //    transform.Rotate(Vector3.up * inputValue * Time.deltaTime * 100.0f);    
       //}

	}

    public void showInventory()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] != null)
            {
                inventory[i].SetActive(true);
                inventory[i].GetComponent<Rigidbody>().useGravity = false;
                inventory[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                inventory[i].GetComponent<Collider>().isTrigger = true;
                inventory[i].transform.position = spawnPoints[i].position;
                inventory[i].transform.rotation = spawnPoints[i].rotation;
            }else
            {
                inventoryHolder[i].SetActive(true);
                inventoryHolder[i].transform.position = spawnPoints[i].position;
                inventoryHolder[i].transform.rotation = spawnPoints[i].rotation;
            }
        }
        
    }

    public void hideInventory()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null) {
                if (beingHeld(inventory[i]))
                {

                    GameObject tempObj = inventory[i];
                    inventory[i] = null;
                    tempObj.GetComponent<Rigidbody>().useGravity = true;
                    tempObj.GetComponent<Collider>().isTrigger = false;
                    tempObj.transform.parent = null;
                    SceneManager.MoveGameObjectToScene(tempObj, SceneManager.GetActiveScene());
                }
                else
                {
                    inventory[i].SetActive(false);
                   
                }
            } else
            {
                inventoryHolder[i].SetActive(false);
               
            }
            
        }

    }

    public bool beingHeld(GameObject obj)
    {
        if(getHoldingHand() == null)
        {
            return false;
        } else
        {
           if (getHoldingHand().grabbedObject.gameObject == obj)
            {
                return true;
            } else
            {
                return false;
            }
        }
        
    }

    public bool AddItem(GameObject obj)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = obj;
                inventory[i].transform.parent = transform;


                return true;
            }
        }
        return false;
    }

    OVRGrabber getHoldingHand()
    {
        if (rightHand.grabbedObject != null)
        {
            return rightHand;
        } else if (leftHand.grabbedObject != null)
        {
            return leftHand;
        } else
        {
            return null;
        }
    }
}
