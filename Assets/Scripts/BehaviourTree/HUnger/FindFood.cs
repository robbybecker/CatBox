using UnityEngine;
using System.Collections;
using System.Linq;
using BehaviourTreeSpace;

[System.Serializable]
public class FindFood : BehaviourNode 
{
	public override NodeStatus Tick (TreeEntity entity)
	{
		GameObject[] food = GameObject.FindGameObjectsWithTag("Food").Where(go => go.GetComponent<Pickupable>().pickedUp == false && go.GetComponent<Consumable>().quantity > 0).ToArray();
		GameObject closestFood = null;
		if(food.Length > 0)
		{
			closestFood = food[0];			
			float distance = Vector3.Distance(entity.transform.position, closestFood.transform.position);
			for(int i = 1; i < food.Length; i++)
			{			
				float newDistance = Vector3.Distance(entity.transform.position, food[i].transform.position);
				if(newDistance < distance)
				{
					closestFood = food[i];
					distance = newDistance;
				}
			}

			object foodPoint;
			if(entity.dataContext == null)
				entity.dataContext = new System.Collections.Generic.Dictionary<string, object>();
			if(entity.dataContext.TryGetValue("moveToLocation", out foodPoint))
			{
				entity.dataContext["moveToLocation"] = closestFood.transform.position;
			}
			else
			{
				entity.dataContext.Add("moveToLocation", closestFood.transform.position);				
			}

			object foodObject;
			if(entity.dataContext.TryGetValue("foodToEat", out foodObject))
			{
				entity.dataContext["foodToEat"] = closestFood;
			}
			else
			{
				entity.dataContext.Add("foodToEat", closestFood);				
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