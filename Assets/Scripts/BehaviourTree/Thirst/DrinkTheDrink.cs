using UnityEngine;
using BehaviourTreeSpace;
using System.Collections;

[System.Serializable]
public class DrinkTheDrink : BehaviourNode
{
	private Drink drink;
	private Thirst thirst;
	private float timer = 0f;
	
	public override void OnEnterNode (TreeEntity entity)
	{
		timer = 0f;
		object outObject;
		if(entity.dataContext.TryGetValue("drink", out outObject))
		{
			if(outObject == null)
			{
				nodeStatus = NodeStatus.Failure;			
			}
			else
			{
				drink = ((GameObject)outObject).GetComponent<Drink>();
				thirst = entity.GetComponent<Thirst>();
			}
		}
		else
		{
			nodeStatus = NodeStatus.Failure;			
		}
	}
	
	public override NodeStatus Tick (TreeEntity entity)
	{
		if(drink == null)
		{
			nodeStatus = NodeStatus.Failure;			
			return nodeStatus;
		}
		if(thirst.thirstState == ThirstState.Quenched || drink.quantity == 0)
		{
			nodeStatus = NodeStatus.Success;
			return nodeStatus;
		}
		if(timer >= 0.1f)
		{
			thirst.Drink(drink);
			timer = 0f;
			nodeStatus = NodeStatus.Running;			
		}
		timer += Time.deltaTime;
		return nodeStatus;
	}
}