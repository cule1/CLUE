using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public SO_Item item;
	public int amount;

	void OnCollisionEnter(Collision other)
	{
		Item _otherItem = other.gameObject.GetComponent<Item>();
		Stack(_otherItem);
		// if(!_otherItem || !item.stackable)
		// {
		// 	return;
		// }
		// if(item == _otherItem.item)
		// {
		// 	if(amount > _otherItem.amount)
		// 	{
		// 		//add to this one
		// 		amount += _otherItem.amount;
		// 		Destroy(_otherItem.gameObject);
		// 	}
		// 	else if(amount == _otherItem.amount)
		// 	{
		// 		//add to the one with the higher magnitude?
		// 		amount += _otherItem.amount;
		// 		Destroy(_otherItem.gameObject);
		// 	}
			
		// }
		
	}

	public void Stack(Item _otherItem)
	{
		print("attempting stack");
		if(!_otherItem || !item.stackable)
		{
			print("items not the same, not stacking: " + _otherItem);
			return;
		}
		if(item == _otherItem.item)
		{
			if(amount > _otherItem.amount)
			{
				//add to this one
				print("stacking");
				amount += _otherItem.amount;
				Destroy(_otherItem.gameObject);
			}
			else if(amount == _otherItem.amount)
			{
				//add to one of them, which ever one gets destroyed last
				print("stacking");
				amount += _otherItem.amount;
				Destroy(_otherItem.gameObject);
			}
			
		}
	}

	public void ForceStack(Item _otherItem)
	{
		print("attempting stack");

		if(_otherItem.gameObject == gameObject)
		{
			print("trying to stack the same item. get outta here with that sauce");
			return;
		}

		if(!_otherItem || !item.stackable)
		{
			print("other item is null, or item is not stackable");
			return;
		}
		if(item == _otherItem.item)
		{
			print("stacking");
			amount += _otherItem.amount;
			Destroy(_otherItem.gameObject);
		}
	}

	public void Split(int _amount, Transform _transform)
	{
		amount -= _amount;
		GameObject _newItem = Instantiate(gameObject);
		_newItem.GetComponent<Item>().amount = _amount;
		_newItem.transform.position = _transform.position;
		_newItem.transform.rotation = _transform.rotation;
	}




}
