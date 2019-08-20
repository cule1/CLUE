using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeHitHandler : MonoBehaviour {

	void OnCollision(Collision other)
	{
		if(other.gameObject.tag == "Pickaxeable")
		{
		//	other.gameObject.GetComponent<HarvestCollisionManager>().DoWork();
		}
	}

}
