using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Inventory : MonoBehaviour {

	public int inventorySize;
	public GameObject[] inventory;
	private GameObject[] privInventory;
	public GameObject inventorySlot;

	void Start()
	{
		privInventory = new GameObject[inventory.Length];
		SpawnPanels();
	}

	public void SpawnPanels()
	{
		for(int i = 0; i < inventory.Length; i++)
		{
			GameObject _newSlot = Instantiate(inventorySlot);
			inventory[i] = _newSlot;

			_newSlot.GetComponent<InventorySlotSnapHandler>().index = i;
			_newSlot.GetComponent<InventorySlotSnapHandler>().inventory = this;

			_newSlot.transform.SetParent(transform);
			_newSlot.transform.localScale = Vector3.one;
			_newSlot.transform.localPosition = Vector3.zero;
			_newSlot.transform.localRotation = Quaternion.identity;
		}
	}

	public void AddItem(GameObject _item)
	{
		print("working here");
		print(_item);
		// check if item in inventory
		for(int i = 0; i < inventory.Length; i++)
		{
			print(privInventory[i]);
			//if item in inventory
			//if there is an item without an item script in the inventory spot, it throws an error because its trying to compare
			//the item script but it doesn't have one on it
			//if(privInventory[i] != null && privInventory[i].GetComponent<Item>() != null && privInventory[i].GetComponent<Item>().item == _item.GetComponent<Item>().item)
			//{
			//	//stack
			//	print("item found, stacking");
			//	privInventory[i].GetComponent<Item>().ForceStack(_item.GetComponent<Item>());
			//	return;
			//}
		}

		//add item to emtpy slot
		for(int i = 0; i < inventory.Length; i++)
		{
			print("looking for new spot");
			if(privInventory[i] == null)
			{
				//inventory[i] = _item;
				print("empty slot found, attempting to snap");
				inventory[i].transform.GetChild(0).GetComponent<VRTK_SnapDropZone>().ForceSnap(_item);
				print("item 'snapped'");
				privInventory[i] = _item;
				return;
			}
		}
			//reference to VRTK_SnapDropZone.ForceSnap(GameObject _item);
		
	}

	public void AddItem(GameObject _item, int _index)
	{
		//if(privInventory[_index] == null)
		//{
			print("item added");
			privInventory[_index] = _item;
		//}
		//else
		//{
		//	print("can't add item slot taken");
		//}
	}

	public void RemoveItem(int _index)
	{
		print("item removed");
		privInventory[_index] = null;
	}


}
