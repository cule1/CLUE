using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InventorySlotSnapHandler : MonoBehaviour {

	public VRTK_SnapDropZone snap;
	public int index;
	public Inventory inventory;

	void Start()
	{
		snap = transform.GetChild(0).GetComponent<VRTK_SnapDropZone>();

		snap.ObjectSnappedToDropZone += OnSnapHandler;
		snap.ObjectUnsnappedFromDropZone += OnUnsnapHandler;
	}

	void OnSnapHandler(object sender, SnapDropZoneEventArgs e)
	{
		inventory.AddItem(e.snappedObject, index);
	}

	void OnUnsnapHandler(object sender, SnapDropZoneEventArgs e)
	{
		inventory.RemoveItem(index);
	}

}
