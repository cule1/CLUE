using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestCollisionHandler : MonoBehaviour {

	public string harvestToolTag;
	public SO_HarvestBase harvestSO;

	void OnCollisionEnter(Collision other)
	{
		print("Collision detected");
		print(other.gameObject);

		foreach (ContactPoint c in other.contacts)
        {
            Debug.Log(c.thisCollider.name);
        }

		if(other.collider.gameObject.tag == harvestToolTag)
		{
			print("Tag correct!");
			harvestSO.DoWork(gameObject);
			print("Called SO's Work Order");
		}
	}

}
