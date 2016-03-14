using UnityEngine;
using System.Collections;
using System.Linq;
using BehaviourTreeSpace;

[System.Serializable]
public class FindDrink : BehaviourNode 
{
	public override NodeStatus Tick (TreeEntity entity)
	{
		GameObject[] drinks = GameObject.FindGameObjectsWithTag("Drink").Where(go => go.GetComponent<Pickupable>().pickedUp == false && go.GetComponent<Consumable>().quantity > 0).ToArray();
		GameObject closestDrink = null;
		if(drinks.Length > 0)
		{
			closestDrink = drinks[0];			
			float distance = Vector3.Distance(entity.transform.position, closestDrink.transform.position);
			for(int i = 1; i < drinks.Length; i++)
			{			
				float newDistance = Vector3.Distance(entity.transform.position, drinks[i].transform.position);
				if(newDistance < distance)
				{
					closestDrink = drinks[i];
					distance = newDistance;
				}
			}
			
			object drinkPoint;
			if(entity.dataContext == null)
				entity.dataContext = new System.Collections.Generic.Dictionary<string, object>();
			if(entity.dataContext.TryGetValue("moveToLocation", out drinkPoint))
			{
				entity.dataContext["moveToLocation"] = closestDrink.transform.position;
			}
			else
			{
				entity.dataContext.Add("moveToLocation", closestDrink.transform.position);				
			}
			
			object drinkObject;
			if(entity.dataContext.TryGetValue("drink", out drinkObject))
			{
				entity.dataContext["drink"] = closestDrink;
			}
			else
			{
				entity.dataContext.Add("drink", closestDrink);				
			}
			nodeStatus = NodeStatus.Success;
		}
		else
		{
			nodeStatus = NodeStatus.Failure;			
		}
		return nodeStatus;
	}
}