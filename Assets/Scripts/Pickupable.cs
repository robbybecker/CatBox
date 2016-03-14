using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour 
{
	private IPickupable iPickupable;
	public bool pickedUp = false;
	
	public void Pickup(GameObject picker)
	{
		if(pickedUp == false)
		{
			pickedUp = true;
			iPickupable = (IPickupable)GetComponent(typeof(IPickupable));
			if(iPickupable == null || picker == null)
				return;
			iPickupable.Pickup(picker);
		}
	}
}