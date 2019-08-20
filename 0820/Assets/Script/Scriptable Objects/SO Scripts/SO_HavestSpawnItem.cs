using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_HavestSpawnItem : SO_HarvestBase
{

	public GameObject item;

    public override void DoWork(GameObject _gameObj)
    {

		Vector3 testPos = new Vector3(_gameObj.transform.position.x, _gameObj.transform.position.y, _gameObj.transform.position.z);

        Instantiate(item, testPos, _gameObj.transform.rotation);
		Debug.Log("Spawned item");
    }
}
